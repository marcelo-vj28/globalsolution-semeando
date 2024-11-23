using Semeando.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Domain.Interfaces
{
    public interface IRespostaRepository
    {
        Task CreateRespostaAsync(RespostaEntity respostaEntity);
        Task<RespostaEntity> GetRespostaByIdAsync(int id);
        Task<IEnumerable<RespostaEntity>> GetAllRespostasAsync();
        Task<IEnumerable<RespostaEntity>> GetAllRespostasByUsuarioIdAsync(int idUsuario);
        Task UpdateRespostaAsync(RespostaEntity respostaEntity);
        Task DeleteRespostaAsync(int id);
    }
}

