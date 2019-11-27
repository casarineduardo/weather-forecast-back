using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastBackend.Entities;

namespace WeatherForecastBackend.Repositories
{
    public class CityRepository : ICityRepository
    {
        public DatabaseContext DbContext { get; set; }

        public CityRepository(DatabaseContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task Add(City data)
        {
            data.Id = Guid.NewGuid();
            await DbContext.City.AddAsync(data);
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(City entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<City>> FindAll()
        {
            return await DbContext.City.ToListAsync();
        }

        public async Task<City> FindById(Guid id)
        {
            return await DbContext.City.FindAsync(id);
        }

        public async Task<City> FindByApiCityCode(int code)
        {
            var cities = await FindAll();
            return cities.Where(x => x.ApiCityCode == code).FirstOrDefault();
        }
    }
}
