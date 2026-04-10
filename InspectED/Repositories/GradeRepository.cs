using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InspectED.Data;
using InspectED.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectED.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _dbContext;

        public GradeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Grade?> GetByIdAsync(int id)
        {
            return await _dbContext.Grades.FindAsync(id);
        }

        public async Task<List<Grade>> GetAllAsync()
        {
            return await _dbContext.Grades.ToListAsync();
        }

        public async Task AddAsync(Grade grade)
        {
            await _dbContext.Grades.AddAsync(grade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Grade grade)
        {
            _dbContext.Grades.Update(grade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var grade = await _dbContext.Grades.FindAsync(id);
            if (grade != null)
            {
                _dbContext.Grades.Remove(grade);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
