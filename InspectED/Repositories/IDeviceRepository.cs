using InspectED.Models;
using InspectED.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InspectED.Repositories
{
    public interface IDeviceRepository
    {
        Task<DeviceViewModel?> GetByIdAsync(int id);

        Task<List<DeviceViewModel>> GetAllAsync();

        Task AddAsync(Device device);

        Task UpdateAsync(Device device);

        Task DeleteAsync(int id);

        Task SaveAsync();

        Task<List<SelectListItem>> GetLocationsAsync();

        Task SeedLocationsAsync();
    }
}