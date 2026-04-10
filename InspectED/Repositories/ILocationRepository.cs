using InspectED.Models;

namespace InspectED.Repositories
{
    public interface ILocationRepository
    {

        Task<Location?> GetByIdAsync(int id);

        Task<List<Location>> GetAllAsync();

        Task AddAsync(Location location);

        Task UpdateAsync(Location location);
        Task DeleteAsync(int id);
    }
}
