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
    }
}
