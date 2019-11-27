using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastBackend.Entities;

namespace WeatherForecastBackend.Repositories
{
    public interface ICityRepository
    {
        Task Add(City data);
        Task Delete(City entity);
        Task<List<City>> FindAll();
        Task<City> FindById(Guid id);
        Task<City> FindByApiCityCode(int code);

    }
}
