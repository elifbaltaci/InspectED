using InspectED.Data;
using InspectED.Models;
using InspectED.ViewModels;
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

        public async Task<List<LocationViewModel>> GetAllAsync()
        {
            var locations = await _dbContext.Locations.ToListAsync();
            List<LocationViewModel> locationViewModels = new List<LocationViewModel>();
            foreach (var location in locations)
            {
                var locationViewModel = new LocationViewModel
                {
                    LocationId = location.LocationId,
                    Name = location.Name
                };

                locationViewModels.Add(locationViewModel);
            }

            return locationViewModels;
        }

        public async Task AddAsync(Location location)
        {
            await _dbContext.Locations.AddAsync(location);
        }

        public async Task UpdateAsync(Location location)
        {
            _dbContext.Locations.Update(location);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var location = await _dbContext.Locations.FindAsync(id);

            if (location != null)
            {
                _dbContext.Locations.Remove(location);
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> LocationExistsAsync(string name)
        {
            return await _dbContext.Locations
                .AnyAsync(l => l.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}