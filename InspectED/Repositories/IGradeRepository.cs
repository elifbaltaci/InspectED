using InspectED.Models;

namespace InspectED.Repositories
{
    public interface IGradeRepository
    {

        Task<Grade?> GetByIdAsync(int id);

        Task<List<Grade>> GetAllAsync();

        Task AddAsync(Grade grade);

        Task UpdateAsync(Grade grade);

        Task DeleteAsync(int id);
    }
}
