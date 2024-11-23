using Microsoft.EntityFrameworkCore;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using Semeando.Infrastructure.Data.AppData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Infrastructure.Data.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly ApplicationDbContext _context;

        public LevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LevelEntity> GetLevelByIdAsync(int id)
        {
            return await _context.Levels.FirstOrDefaultAsync(l => l.IdLevel == id);
        }

        public async Task<IEnumerable<LevelEntity>> GetAllLevelsAsync()
        {
            return await _context.Levels.ToListAsync();
        }

        public async Task CreateLevelAsync(LevelEntity level)
        {
            await _context.Levels.AddAsync(level);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLevelAsync(LevelEntity level)
        {
            _context.Levels.Update(level);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLevelAsync(int id)
        {
            var level = await GetLevelByIdAsync(id);
            if (level != null)
            {
                _context.Levels.Remove(level);
                await _context.SaveChangesAsync();
            }
        }
    }
}
