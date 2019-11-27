using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherForecastBackend.DTOs;
using WeatherForecastBackend.Entities;
using WeatherForecastBackend.Repositories;
using static System.Net.WebRequestMethods;

namespace WeatherForecastBackend.Services
{
    public class CityService : ICityService
    {
        public ICityRepository CityRepository { get; set; }
        public IConfiguration Configuration { get; set; }
        public CityService(ICityRepository cityRepository, IConfiguration configuration)
        {
            this.CityRepository = cityRepository;
            this.Configuration = configuration;
        }
        public async Task<City> Add(CityDTO data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string baseURL =
                    Configuration.GetSection("WeatherForecastApi:BaseURL").Value;
                string key =
                    Configuration.GetSection("WeatherForecastApi:ApiKey").Value;
                HttpResponseMessage response = await client.GetAsync(
                    baseURL + "/weather?" +
                    $"APPID={key}&" +
                    $"q={data.Name}");

                response.EnsureSuccessStatusCode();
                string bodyResponse = await response.Content.ReadAsStringAsync();

                WeatherForecastCityDTO result = JsonConvert.DeserializeObject<WeatherForecastCityDTO>(bodyResponse);

                Boolean cityExists = await CityRepository.FindByApiCityCode(result.Id) != null;
                if (cityExists)
                {
                    throw new Exception("Cidade já cadastrada!");
                }

                var newCity = new City()
                {
                    Name = data.Name,
                    ApiCityCode = result.Id
                };
                await CityRepository.Add(newCity);
                return newCity;
            }
            
        }

        public async Task Delete(Guid id)
        {
            var city = await CityRepository.FindById(id);
            await CityRepository.Delete(city);
        }

        public async Task<List<CityDTO>> FindAll()
        {
            return (await CityRepository.FindAll())
             .Select(x => CityDTO.FromCity(x))
             .ToList();
        }

        public async Task<CityDTO> FindById(Guid id)
        {
            var entity = await CityRepository.FindById(id);
            return CityDTO.FromCity(entity);
        }
    }
}
