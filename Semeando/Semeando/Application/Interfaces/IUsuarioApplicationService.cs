using Semeando.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Task<UsuarioDto> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();
        Task CreateUsuarioAsync(UsuarioDto usuarioDto);
        Task UpdateUsuarioAsync(UsuarioDto usuarioDto);
        Task DeleteUsuarioAsync(int id);
    }
}


