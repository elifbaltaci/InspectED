using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InspectED.Data;
using InspectED.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectED.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await _dbContext.Locations.FindAsync(id);
        }

        public async Task<List<Location>> GetAllAsync()
        {
            return await _dbContext.Locations.ToListAsync();
        }

        public async Task AddAsync(Location location)
        {
            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Location location)
        {
            _dbContext.Locations.Update(location);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var location = await _dbContext.Locations.FindAsync(id);
            if (location != null)
            {
                _dbContext.Locations.Remove(location);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
