using Semeando.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Domain.Interfaces
{
    public interface ILevelRepository
    {
        Task CreateLevelAsync(LevelEntity levelEntity);
        Task<LevelEntity> GetLevelByIdAsync(int id);
        Task<IEnumerable<LevelEntity>> GetAllLevelsAsync();
        Task UpdateLevelAsync(LevelEntity levelEntity);
        Task DeleteLevelAsync(int id);
    }
}

