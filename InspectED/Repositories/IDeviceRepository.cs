using InspectED.Models;

namespace InspectED.Repositories
{
    public interface IDeviceRepository
    {

        Task<Device?> GetByIdAsync(int id);

        Task<List<Device>> GetAllAsync();

        Task AddAsync(Device device);

        Task UpdateAsync(Device device);   

        Task DeleteAsync(int id);

    }
}
