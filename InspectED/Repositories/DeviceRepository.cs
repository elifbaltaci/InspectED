using InspectED.Data;
using InspectED.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InspectED.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _dbContext;
        public DeviceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Device?> GetByIdAsync(int id)
        {
            return await _dbContext.Devices.FindAsync(id);
        }

        public async Task<List<Device>> GetAllAsync()
        {
            return await _dbContext.Devices.ToListAsync();
        }

        public async Task AddAsync(Device device)
        {
       
            await _dbContext.Devices.AddAsync(device);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Device device)
        {
            _dbContext.Devices.Update(device);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var device = await _dbContext.Devices.FindAsync(Id);
            if (device == null)
            {
                // No-op if not found; alternatively throw if you prefer
                return;
            }

            _dbContext.Devices.Remove(device);
            await _dbContext.SaveChangesAsync();
        }
    }
}
