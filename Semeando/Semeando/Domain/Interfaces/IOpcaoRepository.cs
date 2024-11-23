using Semeando.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Domain.Interfaces
{
    public interface IOpcaoRepository
    {
        Task CreateOpcaoAsync(OpcaoEntity opcaoEntity);
        Task<OpcaoEntity> GetOpcaoByIdAsync(int idOpcao);
        Task<IEnumerable<OpcaoEntity>> GetAllOpcoesAsync();
        Task<IEnumerable<OpcaoEntity>> GetAllOpcoesByPerguntaIdAsync(int idPergunta);
        Task UpdateOpcaoAsync(OpcaoEntity opcaoEntity);
        Task DeleteOpcaoAsync(int idOpcao);
    }
}


