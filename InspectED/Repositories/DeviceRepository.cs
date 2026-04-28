using InspectED.Data;
using InspectED.Models;
using InspectED.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InspectED.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DeviceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Device?> GetByIdAsync(int id)
        {
            return await _dbContext.Devices
                .Include(d => d.Location)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DeviceViewModel>> GetAllAsync()
        {
            return await _dbContext.Devices
                .Include(d => d.Location)
                .Select(device => new DeviceViewModel
                {
                    Id = device.Id,
                    AssetTag = device.AssetTag,
                    SerialNumber = device.SerialNumber,
                    DeviceModel = device.DeviceModel,
                    AssignedUserEmail = device.AssignedUserEmail,
                    Location = device.Location != null ? device.Location.Name : "Unknown",
                    LocationId = device.LocationId,
                    ScreenCondition = device.ScreenCondition,
                    KeyboardCondition = device.KeyboardCondition,
                    BatteryCondition = device.BatteryCondition,
                    ChargerAvailable = device.ChargerAvailable,
                    WifiWorking = device.WifiWorking,
                    TestingReady = device.TestingReady,
                    InspectionDate = device.InspectionDate,
                    Notes = device.Notes
                })
                .ToListAsync();
        }

        public async Task AddAsync(Device device)
        {
            await _dbContext.Devices.AddAsync(device);
        }

        public async Task UpdateAsync(Device device)
        {
            _dbContext.Devices.Update(device);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var device = await _dbContext.Devices.FindAsync(id);

            if (device == null)
            {
                return;
            }

            _dbContext.Devices.Remove(device);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SelectListItem>> GetLocationsAsync()
        {
            return await _dbContext.Locations
                .OrderBy(l => l.Name)
                .Select(l => new SelectListItem
                {
                    Value = l.LocationId.ToString(),
                    Text = l.Name
                })
                .ToListAsync();
        }

        public async Task SeedLocationsAsync()
        {
            var defaultLocations = new List<string>
            {
                "1/A", "1/B",
                "2/A", "2/B",
                "3/A", "3/B",
                "4/A", "4/B",
                "5/A", "5/B"
            };

            foreach (var name in defaultLocations)
            {
                bool exists = await _dbContext.Locations
                    .AnyAsync(l => l.Name.ToLower().Trim() == name.ToLower().Trim());

                if (!exists)
                {
                    await _dbContext.Locations.AddAsync(new Location
                    {
                        Name = name
                    });
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}