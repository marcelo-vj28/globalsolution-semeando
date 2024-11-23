using Semeando.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Application.Interfaces
{
    public interface IRespostaApplicationService
    {
        Task<RespostaDto> GetRespostaByIdAsync(int id);
        Task<IEnumerable<RespostaDto>> GetAllRespostasByUsuarioIdAsync(int idUsuario);
        Task CreateRespostaAsync(RespostaDto respostaDto);
        Task UpdateRespostaAsync(RespostaDto respostaDto);
        Task DeleteRespostaAsync(int id);
        Task<IEnumerable<RespostaDto>> GetAllRespostasAsync();
    }
}


