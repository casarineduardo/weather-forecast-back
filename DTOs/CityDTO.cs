using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastBackend.Entities;

namespace WeatherForecastBackend.DTOs
{
    public class CityDTO
    {
        public string Name { get; set; }
        public int ApiCityCode { get; set; }
        public String Id { get; set; }

        internal static CityDTO FromCity(City entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new CityDTO()
            {
                Name = entity.Name,
                ApiCityCode = entity.ApiCityCode,
                Id = entity.Id.ToString()
            };
        }
    }
}
