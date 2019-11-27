using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastBackend.Entities
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ApiCityCode { get; set; }

    }
}
