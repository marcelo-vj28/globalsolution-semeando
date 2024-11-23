using Semeando.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Domain.Interfaces
{
    public interface IPerguntaRepository
    {
        Task CreatePerguntaAsync(PerguntaEntity perguntaEntity);
        Task<PerguntaEntity> GetPerguntaByIdAsync(int id);
        Task<IEnumerable<PerguntaEntity>> GetAllPerguntasAsync();
        Task<IEnumerable<PerguntaEntity>> GetAllPerguntasByLevelIdAsync(int idLevel);
        Task UpdatePerguntaAsync(PerguntaEntity perguntaEntity);
        Task DeletePerguntaAsync(int id);
    }
}

