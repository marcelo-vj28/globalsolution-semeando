using Microsoft.AspNetCore.Mvc;
using Semeando.Application.Dtos;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using Semeando.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Controllers
{
    public class RespostaController : Controller
    {
        private readonly IRespostaRepository _respostaRepository;
        private readonly IPerguntaRepository _perguntaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public RespostaController(
            IRespostaRepository respostaRepository,
            IPerguntaRepository perguntaRepository,
            IUsuarioRepository usuarioRepository)
        {
            _respostaRepository = respostaRepository;
            _perguntaRepository = perguntaRepository;
            _usuarioRepository = usuarioRepository;
        }

        private async Task PreencherPerguntasViewBagAsync()
        {
            var perguntas = await _perguntaRepository.GetAllPerguntasAsync();
            ViewBag.Perguntas = perguntas.Select(p => new PerguntaModel
            {
                IdPergunta = p.IdPergunta,
                Texto = p.Texto
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> CreateResposta()
        {
            await PreencherPerguntasViewBagAsync();
            return View("CadastroResposta", new RespostaModel());
        }

        [HttpPost]
        public async Task<IActionResult> CadastroResposta(RespostaDto respostaDto)
        {
            if (ModelState.IsValid)
            {
                var usuarioExiste = await _usuarioRepository.GetUsuarioByIdAsync(respostaDto.IdUsuario);
                if (usuarioExiste == null)
                {
                    ModelState.AddModelError(string.Empty, "Usuário não encontrado.");
                    await PreencherPerguntasViewBagAsync();
                    return View("CadastroResposta", respostaDto);
                }

                var respostaEntity = new RespostaEntity
                {
                    IdUsuario = respostaDto.IdUsuario,
                    IdPergunta = respostaDto.IdPergunta,
                    OpcaoEscolhida = respostaDto.OpcaoEscolhida
                };

                await _respostaRepository.CreateRespostaAsync(respostaEntity);
                return RedirectToAction("ConsultaResposta");
            }

            await PreencherPerguntasViewBagAsync();
            return View("CadastroResposta", respostaDto);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaResposta()
        {
            var respostas = await _respostaRepository.GetAllRespostasAsync();
            var respostasModel = respostas.Select(r => new RespostaModel
            {
                IdResposta = r.IdResposta,
                IdUsuario = r.IdUsuario,
                IdPergunta = r.IdPergunta,
                OpcaoEscolhida = r.OpcaoEscolhida
            }).ToList();

            return View("ConsultaResposta", respostasModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditarResposta(int idResposta)
        {
            var respostaEntity = await _respostaRepository.GetRespostaByIdAsync(idResposta);
            if (respostaEntity == null)
            {
                return NotFound();
            }

            await PreencherPerguntasViewBagAsync();

            var respostaModel = new RespostaModel
            {
                IdResposta = respostaEntity.IdResposta,
                IdUsuario = respostaEntity.IdUsuario,
                IdPergunta = respostaEntity.IdPergunta,
                OpcaoEscolhida = respostaEntity.OpcaoEscolhida
            };

            return View("EditarResposta", respostaModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarResposta(RespostaDto respostaDto)
        {
            if (ModelState.IsValid)
            {
                var usuarioExiste = await _usuarioRepository.GetUsuarioByIdAsync(respostaDto.IdUsuario);
                if (usuarioExiste == null)
                {
                    ModelState.AddModelError(string.Empty, "Usuário não encontrado.");
                    await PreencherPerguntasViewBagAsync();
                    return View("EditarResposta", respostaDto);
                }

                var respostaEntity = new RespostaEntity
                {
                    IdResposta = respostaDto.IdResposta,
                    IdUsuario = respostaDto.IdUsuario,
                    IdPergunta = respostaDto.IdPergunta,
                    OpcaoEscolhida = respostaDto.OpcaoEscolhida
                };

                await _respostaRepository.UpdateRespostaAsync(respostaEntity);
                return RedirectToAction("ConsultaResposta");
            }

            await PreencherPerguntasViewBagAsync();
            return View("EditarResposta", respostaDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarResposta(int idResposta)
        {
            await _respostaRepository.DeleteRespostaAsync(idResposta);
            return RedirectToAction("ConsultaResposta");
        }
    }
}





