using Family.Core.DTOs.Identity;
using Family.Core.Identity;
using Family.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Family.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            IEmailService emailService,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized("Invalid email");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid password");

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            return new UserDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = await _tokenService.CreateToken(user),
                IsAdmin = isAdmin
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
            {
                return BadRequest("Email already in use");
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            // Add user to regular "User" role by default
            await _userManager.AddToRoleAsync(user, "User");

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                IsAdmin = false
            };
        }

        [HttpPost("forgotpassword")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
                if (user == null)
                    return Ok(new { message = "If your email is registered, you will receive password reset instructions." });

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetLink = $"{Request.Scheme}://{Request.Host}/reset-password?email={WebUtility.UrlEncode(user.Email)}&token={WebUtility.UrlEncode(token)}";

                try
                {
                    await _emailService.SendEmailAsync(
                        user.Email,
                        "Reset Your Password - Family App",
                        GetPasswordResetEmailTemplate(user.DisplayName, resetLink));

                    return Ok(new { message = "Password reset instructions have been sent to your email." });
                }
                catch (Exception ex)
                {
                    // Log the error details
                    return StatusCode(500, new { message = "Failed to send reset email. Please try again later." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }

        private string GetPasswordResetEmailTemplate(string userName, string resetLink)
        {
            return $@"
        <html>
            <body style='font-family: Arial, sans-serif;'>
                <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                    <h2 style='color: #333;'>Reset Your Password</h2>
                    <p>Hello {userName},</p>
                    <p>You have requested to reset your password. Please click the button below to set a new password:</p>
                    <div style='text-align: center; margin: 30px 0;'>
                        <a href='{resetLink}' 
                           style='background-color: #4CAF50; color: white; padding: 12px 25px; 
                                  text-decoration: none; border-radius: 3px; display: inline-block;'>
                            Reset Password
                        </a>
                    </div>
                    <p>If you didn't request this, please ignore this email.</p>
                    <p>The link will expire in 24 hours.</p>
                    <p>Best regards,<br>Family App Team</p>
                </div>
            </body>
        </html>";
        }

        [HttpPost("resetpassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
                if (user == null)
                    return BadRequest("Invalid request");

                var result = await _userManager.ResetPasswordAsync(
                    user,
                    resetPasswordDto.Token,
                    resetPasswordDto.NewPassword);

                if (!result.Succeeded)
                    return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });

                // Send confirmation email
                var emailBody = $@"
                <h2>Password Reset Successful</h2>
                <p>Hello {user.DisplayName},</p>
                <p>Your password has been successfully reset.</p>
                <p>If you didn't make this change, please contact us immediately.</p>
                <p>Best regards,<br>Family App Team</p>";

                await _emailService.SendEmailAsync(
                    user.Email,
                    "Password Reset Successful - Family App",
                    emailBody);

                return Ok(new { message = "Password has been reset successfully" });
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }
    }
}
