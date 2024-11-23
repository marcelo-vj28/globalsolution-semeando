using Microsoft.AspNetCore.Mvc;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using Semeando.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Exibição da tela de cadastro de usuário
        [HttpGet]
        [Route("CreateUsuarioAsync")]
        public IActionResult CreateUsuario()
        {
            var usuarioModel = new UsuarioModel();
            return View("CadastroUsuario", usuarioModel);
        }

        // Método para criar e cadastrar um novo usuário
        [HttpPost]
        [Route("CreateUsuarioAsync")]
        public async Task<IActionResult> CreateUsuario(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioEntity = new UsuarioEntity
                {
                    Nome = usuarioModel.Nome,
                    Email = usuarioModel.Email,
                    Ranking = usuarioModel.Ranking
                };

                await _usuarioRepository.CreateUsuarioAsync(usuarioEntity);
                return RedirectToAction("GetAllUsuariosAsync");
            }

            return View("CadastroUsuario", usuarioModel);
        }

        // Exibição da tela de consulta de usuários
        [HttpGet]
        [Route("GetAllUsuariosAsync")]
        public async Task<IActionResult> ViewUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
            var usuariosModel = usuarios.Select(u => new UsuarioModel
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                Ranking = u.Ranking
            }).ToList();

            return View("ConsultaUsuario", usuariosModel);
        }

        // Exibição da tela de edição de usuário
        [HttpGet]
        [Route("GetUsuarioByIdAsync/{idUsuario}")]
        public async Task<IActionResult> ViewUsuarios(int idUsuario)
        {
            var usuarioEntity = await _usuarioRepository.GetUsuarioByIdAsync(idUsuario);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            var usuarioModel = new UsuarioModel
            {
                IdUsuario = usuarioEntity.IdUsuario,
                Nome = usuarioEntity.Nome,
                Email = usuarioEntity.Email,
                Ranking = usuarioEntity.Ranking
            };

            return View("EditarUsuario", usuarioModel);
        }

        // Método para editar os dados do usuário
        [HttpPost]
        [Route("UpdateUsuarioAsync")]
        public async Task<IActionResult> EditUsuario(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioEntity = new UsuarioEntity
                {
                    IdUsuario = usuarioModel.IdUsuario,
                    Nome = usuarioModel.Nome,
                    Email = usuarioModel.Email,
                    Ranking = usuarioModel.Ranking
                };

                await _usuarioRepository.UpdateUsuarioAsync(usuarioEntity);
                return RedirectToAction("GetAllUsuariosAsync");
            }

            return View("EditarUsuario", usuarioModel);
        }

        // Método para deletar um usuário
        [HttpDelete]
        [Route("DeleteUsuarioAsync")]
        public async Task<IActionResult> DeleteUsuario(int idUsuario)
        {
            await _usuarioRepository.DeleteUsuarioAsync(idUsuario);
            return RedirectToAction("GetAllUsuariosAsync");
        }
    }
}