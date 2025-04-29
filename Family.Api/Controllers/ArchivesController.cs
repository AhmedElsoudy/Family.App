using Family.Core.Entities;
using Family.Core.Repository.Interfaces;
using Family.Core.Specifications.PhotoSpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Family.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivesController : ControllerBase
    {
        private readonly IGenericRepository<Photo> _archivesRepo;

        public ArchivesController(IGenericRepository<Photo> archivesRepo)
        {
            _archivesRepo = archivesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetAllArchives()
        {
            var spec = new PhotoSpecification();
            var archives = await _archivesRepo.ListAsync(spec);
            return Ok(archives);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetArchive(int id)
        {
            var spec = new PhotoSpecification(id);
            var photo = await _archivesRepo.GetBySpecification(spec);

            if (photo == null)
                return NotFound($"Photo with ID {id} not found");

            return Ok(photo);
        }



    }
}
