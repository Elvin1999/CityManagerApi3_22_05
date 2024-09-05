using CityManagerApi3_22_05.Data.Abstract;
using CityManagerApi3_22_05.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityManagerApi3_22_05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IAppRepository _appRepository;

        public CityController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        // GET: api/<CityController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCities(int id)
        {
            var dtos = (await _appRepository.GetCitiesAsync(id))
                .Select(c =>
                {
                    return new CityForListDto
                    {
                        Description = c.Description,
                        Id = c.Id,
                        Name = c.Name,
                        PhotoUrl = c.CityImages?.FirstOrDefault(p => p.IsMain)?.Url
                    };
                });
            return Ok(dtos);
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
