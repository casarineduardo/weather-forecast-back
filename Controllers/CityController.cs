using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastBackend.DTOs;
using WeatherForecastBackend.Services;

namespace WeatherForecastBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public ICityService Service { get; set; }

        public CityController(ICityService cityService)
        {
            this.Service = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> Get()
        {
            return Ok(await Service.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await Service.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CityDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Service.Add(value);

            return Ok(new
            {
                Success = true,
                Id = entity.Id
            });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await Service.Delete(id);
            return Ok(new
            {
                Success = true,
                Id = id
            });
        }
    }
}