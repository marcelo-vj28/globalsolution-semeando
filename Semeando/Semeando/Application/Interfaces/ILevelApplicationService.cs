using Semeando.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Application.Interfaces
{
    public interface ILevelApplicationService
    {
        Task<LevelDto> GetLevelByIdAsync(int id);
        Task<IEnumerable<LevelDto>> GetAllLevelsAsync();
        Task CreateLevelAsync(LevelDto levelDto);
        Task UpdateLevelAsync(LevelDto levelDto);
        Task DeleteLevelAsync(int id);
    }
}



