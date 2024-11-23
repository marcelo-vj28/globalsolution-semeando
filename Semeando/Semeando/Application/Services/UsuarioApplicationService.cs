using Semeando.Application.Dtos;
using Semeando.Application.Interfaces;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semeando.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplicationService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuarioEntity = new UsuarioEntity
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Ranking = usuarioDto.Ranking
            };

            await _usuarioRepository.CreateUsuarioAsync(usuarioEntity);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteUsuarioAsync(id);
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
            var usuarioDtos = new List<UsuarioDto>();

            foreach (var usuario in usuarios)
            {
                usuarioDtos.Add(new UsuarioDto
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Ranking = usuario.Ranking
                });
            }

            return usuarioDtos;
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Ranking = usuario.Ranking
            };
        }

        public async Task UpdateUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuarioEntity = new UsuarioEntity
            {
                IdUsuario = usuarioDto.IdUsuario,
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Ranking = usuarioDto.Ranking
            };

            await _usuarioRepository.UpdateUsuarioAsync(usuarioEntity);
        }
    }
}

