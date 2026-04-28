using InspectED.Models;
using InspectED.ViewModels;

namespace InspectED.Repositories
{
    public interface ILocationRepository
    {
        Task<Location?> GetByIdAsync(int id);

        Task<List<LocationViewModel>> GetAllAsync();

        Task AddAsync(Location location);

        Task UpdateAsync(Location location);

        Task DeleteAsync(int id);

        Task SaveAsync();

        Task<bool> LocationExistsAsync(string name);
    }
}