using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastBackend.DTOs;
using WeatherForecastBackend.Entities;

namespace WeatherForecastBackend.Services
{
    public interface ICityService
    {
        Task<City> Add(CityDTO data);
        Task Delete(Guid id);
        Task<List<CityDTO>> FindAll();
        Task<CityDTO> FindById(Guid id);
    }
}
