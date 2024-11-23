using Semeando.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task CreateUsuarioAsync(UsuarioEntity usuario);
        Task<UsuarioEntity> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<UsuarioEntity>> GetAllUsuariosAsync();
        Task UpdateUsuarioAsync(UsuarioEntity usuario);
        Task DeleteUsuarioAsync(int id);
    }
}

