using Family.Core.Entities;
using Family.Core.Repository.Interfaces;
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
            var archives = await _archivesRepo.GetAllAsync();
            return Ok(archives);
        }



    }
}
