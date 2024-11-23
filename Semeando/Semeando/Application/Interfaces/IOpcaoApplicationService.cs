using Semeando.Application.Dtos;
using Semeando.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Application.Interfaces
{
    public interface IOpcaoApplicationService
    {
        Task<OpcaoDto> GetOpcaoByIdAsync(int idOpcao);
        Task<IEnumerable<OpcaoDto>> GetAllOpcoesAsync();
        Task<IEnumerable<OpcaoDto>> GetAllOpcoesByPerguntaIdAsync(int idPergunta);
        Task CreateOpcaoAsync(OpcaoDto opcaoDto);
        Task UpdateOpcaoAsync(OpcaoDto opcaoDto);
        Task DeleteOpcaoAsync(int idOpcao);
    }
}

