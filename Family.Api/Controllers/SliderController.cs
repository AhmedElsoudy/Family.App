using Family.Core.Entities;
using Family.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Family.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly IGenericRepository<SliderItem> _sliderItemRepo;

        public SliderController(IGenericRepository<SliderItem> SliderItemRepo)
        {
            _sliderItemRepo = SliderItemRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SliderItem>>> GetAll()
        {
            var sliderItems = await _sliderItemRepo.GetAllAsync();
            return Ok(sliderItems);

        }

    }
}
