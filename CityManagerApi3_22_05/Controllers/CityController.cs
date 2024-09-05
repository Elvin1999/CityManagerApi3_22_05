using AutoMapper;
using CityManagerApi3_22_05.Data.Abstract;
using CityManagerApi3_22_05.Dtos;
using CityManagerApi3_22_05.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityManagerApi3_22_05.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public CityController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        // GET: api/<CityController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCities(int id)
        {
            //var dtos = (await _appRepository.GetCitiesAsync(id))
            //    .Select(c =>
            //    {
            //        return new CityForListDto
            //        {
            //            Description = c.Description,
            //            Id = c.Id,
            //            Name = c.Name,
            //            PhotoUrl = c.CityImages?.FirstOrDefault(p => p.IsMain)?.Url
            //        };
            //    });
            //return Ok(dtos);

            var items = await _appRepository.GetCitiesAsync(id);
            var dtos = _mapper.Map<IEnumerable<CityForListDto>>(items);
            return Ok(dtos);
        }

        // POST api/<CityController>
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] CityDto dto)
        {
            var entity = _mapper.Map<City>(dto);
            await _appRepository.AddAsync(entity);
            await _appRepository.SaveAllAsync();
            var returnedDto=_mapper.Map<CityDto>(entity);
            return Ok(returnedDto); 
        }
    }
}
