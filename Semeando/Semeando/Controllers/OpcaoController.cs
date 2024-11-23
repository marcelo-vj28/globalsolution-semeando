using Microsoft.AspNetCore.Mvc;
using Semeando.Application.Dtos;
using Semeando.Application.Interfaces;
using Semeando.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Controllers
{
    public class OpcaoController : Controller
    {
        private readonly IOpcaoApplicationService _opcaoApplicationService;

        public OpcaoController(IOpcaoApplicationService opcaoApplicationService)
        {
            _opcaoApplicationService = opcaoApplicationService;
        }

        private async Task FillViewBagAsync()
        {
            var opcoesDto = await _opcaoApplicationService.GetAllOpcoesAsync();
            var opcoesModel = opcoesDto.Select(o => new OpcaoModel
            {
                IdOpcao = o.IdOpcao,
                IdPergunta = o.IdPergunta,
                Texto = o.Texto,
                OpcaoCorreta = o.OpcaoCorreta
            }).ToList();

            ViewBag.Opcoes = opcoesModel;
        }

        // Cadastro (GET)
        [HttpGet]
        public async Task<IActionResult> CreateOpcao()
        {
            await FillViewBagAsync();
            return View("CreateOpcao", new OpcaoModel());
        }

        // Cadastro (POST)
        [HttpPost]
        public async Task<IActionResult> CreateOpcao(OpcaoModel opcaoModel)
        {
            if (ModelState.IsValid)
            {
                var opcaoDto = new OpcaoDto
                {
                    IdPergunta = opcaoModel.IdPergunta,
                    Texto = opcaoModel.Texto,
                    OpcaoCorreta = opcaoModel.OpcaoCorreta
                };

                await _opcaoApplicationService.CreateOpcaoAsync(opcaoDto);
                return RedirectToAction("ViewOpcoes");
            }

            await FillViewBagAsync();
            return View("CreateOpcao", opcaoModel);
        }

        // Consulta (GET)
        [HttpGet]
        public async Task<IActionResult> ViewOpcoes()
        {
            var opcoesDto = await _opcaoApplicationService.GetAllOpcoesAsync();
            var opcoesModel = opcoesDto.Select(o => new OpcaoModel
            {
                IdOpcao = o.IdOpcao,
                IdPergunta = o.IdPergunta,
                Texto = o.Texto,
                OpcaoCorreta = o.OpcaoCorreta
            }).ToList();

            return View("ViewOpcoes", opcoesModel);
        }

        // Edição (GET)
        [HttpGet]
        public async Task<IActionResult> EditOpcao(int idOpcao)
        {
            var opcaoDto = await _opcaoApplicationService.GetOpcaoByIdAsync(idOpcao);
            if (opcaoDto == null)
            {
                return NotFound();
            }

            await FillViewBagAsync();

            var opcaoModel = new OpcaoModel
            {
                IdOpcao = opcaoDto.IdOpcao,
                IdPergunta = opcaoDto.IdPergunta,
                Texto = opcaoDto.Texto,
                OpcaoCorreta = opcaoDto.OpcaoCorreta
            };

            return View("EditOpcao", opcaoModel);
        }

        // Edição (POST)
        [HttpPost]
        public async Task<IActionResult> EditOpcao(OpcaoModel opcaoModel)
        {
            if (ModelState.IsValid)
            {
                var opcaoDto = new OpcaoDto
                {
                    IdOpcao = opcaoModel.IdOpcao,
                    IdPergunta = opcaoModel.IdPergunta,
                    Texto = opcaoModel.Texto,
                    OpcaoCorreta = opcaoModel.OpcaoCorreta
                };

                await _opcaoApplicationService.UpdateOpcaoAsync(opcaoDto);
                return RedirectToAction("ViewOpcoes");
            }

            await FillViewBagAsync();
            return View("EditOpcao", opcaoModel);
        }

        // Exclusão (POST)
        [HttpPost]
        public async Task<IActionResult> DeleteOpcao(int idOpcao)
        {
            await _opcaoApplicationService.DeleteOpcaoAsync(idOpcao);
            return RedirectToAction("ViewOpcoes");
        }

        // Consulta por Pergunta (GET)
        [HttpGet]
        public async Task<IActionResult> ViewOpcoesByQuestion(int questionId)
        {
            var opcoesDto = await _opcaoApplicationService.GetAllOpcoesByPerguntaIdAsync(questionId);
            var opcoesModel = opcoesDto.Select(o => new OpcaoModel
            {
                IdOpcao = o.IdOpcao,
                IdPergunta = o.IdPergunta,
                Texto = o.Texto,
                OpcaoCorreta = o.OpcaoCorreta
            }).ToList();

            return View("ViewOpcoes", opcoesModel);
        }
    }
}

