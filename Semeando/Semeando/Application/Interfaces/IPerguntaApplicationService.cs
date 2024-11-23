using Semeando.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Application.Interfaces
{
    public interface IPerguntaApplicationService
    {
        Task<PerguntaDto> GetPerguntaByIdAsync(int id);
        Task<IEnumerable<PerguntaDto>> GetAllPerguntasByLevelIdAsync(int idLevel);
        Task CreatePerguntaAsync(PerguntaDto perguntaDto);
        Task UpdatePerguntaAsync(PerguntaDto perguntaDto);
        Task DeletePerguntaAsync(int id);
        Task<IEnumerable<PerguntaDto>> GetAllPerguntasAsync();
    }
}


