using Family.Api.Helpers;
using Family.Core.DTOs;
using Family.Core.Entities;
using Family.Core.Repository.Interfaces;
using Family.Core.Specifications.BranchSpecifications;
using Family.Core.Specifications.ClanSpecifications;
using Family.Core.Specifications.PersonSpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Family.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IGenericRepository<Clan> _clanRepo;
        private readonly IGenericRepository<Branch> _branchRepo;
        private readonly IGenericRepository<Person> _personRepo;

        public FamilyController(
            IGenericRepository<Clan> clanRepo,
            IGenericRepository<Branch> branchRepo,
            IGenericRepository<Person> personRepo)
        {
            _clanRepo = clanRepo;
            _branchRepo = branchRepo;
            _personRepo = personRepo;
        }

        [HttpGet("clans")]
        public async Task<ActionResult<IEnumerable<ClanDto>>> GetAllClans()
        {
            var spec = new ClanWithBranchesSpecification();
            var clans = await _clanRepo.ListAsync(spec);
            return Ok(clans.ToDtos());
        }

        [HttpGet("clans/{clanId}")]
        public async Task<ActionResult<Clan>> GetClanWithBranches(int clanId)
        {
            var spec = new ClanWithBranchesSpecification(clanId);
            var clan = await _clanRepo.GetBySpecification(spec);

            if (clan == null)
                return NotFound($"Clan with ID {clanId} not found");

            return Ok(clan);
        }

        [HttpGet("branches/{branchId}")]
        public async Task<ActionResult<Branch>> GetBranchWithPersons(int branchId)
        {
            var spec = new BranchWithPersonsSpecification(branchId);
            var branch = await _branchRepo.GetBySpecification(spec);

            if (branch == null)
                return NotFound($"Branch with ID {branchId} not found");

            return Ok(branch);
        }

        [HttpGet("persons/{personId}")]
        public async Task<ActionResult<Person>> GetPersonDetails(int personId)
        {
            var spec = new PersonWithDetailsSpecification(personId);
            var person = await _personRepo.GetBySpecification(spec);

            if (person == null)
                return NotFound($"Person with ID {personId} not found");

            return Ok(person);
        }

        [HttpGet("clans/{clanId}/branches")]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetBranchesByClanId(int clanId)
        {
            var spec = new BranchWithPersonsSpecification(clanId, true);
            var branches = await _branchRepo.ListAsync(spec);
            return Ok(branches.ToDtos());
        }

        [HttpGet("branches/{branchId}/persons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsByBranchId(int branchId)
        {
            var spec = new PersonWithDetailsSpecification(branchId, true);
            var persons = await _personRepo.ListAsync(spec);
            return Ok(persons);
        }
    }
}
