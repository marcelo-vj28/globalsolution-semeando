using Semeando.Application.Interfaces;
using Semeando.Application.Services;
using Semeando.Models;
using Semeando.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Controllers
{
    public class PerguntaController : Controller
    {
        private readonly IPerguntaApplicationService _perguntaApplicationService;
        private readonly ILevelApplicationService _levelApplicationService;

        public PerguntaController(
            IPerguntaApplicationService perguntaApplicationService,
            ILevelApplicationService levelApplicationService)
        {
            _perguntaApplicationService = perguntaApplicationService;
            _levelApplicationService = levelApplicationService;
        }

        private async Task FillLevelsViewBagAsync()
        {
            var levelsDto = await _levelApplicationService.GetAllLevelsAsync();
            var levelsModel = levelsDto.Select(l => new LevelModel
            {
                IdLevel = l.IdLevel,
                Titulo = l.Titulo,
                Descricao = l.Descricao,
                Dificuldade = l.Dificuldade
            }).ToList();

            ViewBag.Levels = levelsModel;
        }

        private void PreencherTiposPerguntaViewBag()
        {
            ViewBag.TiposPergunta = new List<string>
            {
                "Múltipla Escolha",
                "Verdadeiro ou Falso",
                "Dissertativa"
            };
        }

        [HttpGet]
        public async Task<IActionResult> CreatePergunta()
        {
            await FillLevelsViewBagAsync();
            PreencherTiposPerguntaViewBag();
            return View("CadastroPergunta", new PerguntaModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePergunta(PerguntaModel perguntaModel)
        {
            if (ModelState.IsValid)
            {
                var perguntaDto = new PerguntaDto
                {
                    IdLevel = perguntaModel.IdLevel,
                    Texto = perguntaModel.Texto,
                    TipoPergunta = perguntaModel.TipoPergunta
                };

                await _perguntaApplicationService.CreatePerguntaAsync(perguntaDto);
                return RedirectToAction("ConsultaPergunta");
            }

            await FillLevelsViewBagAsync();
            PreencherTiposPerguntaViewBag();
            return View("CadastroPergunta", perguntaModel);
        }

        [HttpGet]
        public async Task<IActionResult> ViewPergunta()
        {
            var perguntasDto = await _perguntaApplicationService.GetAllPerguntasAsync();
            var perguntasModel = perguntasDto.Select(p => new PerguntaModel
            {
                IdPergunta = p.IdPergunta,
                IdLevel = p.IdLevel,
                Texto = p.Texto,
                TipoPergunta = p.TipoPergunta
            }).ToList();

            return View("ConsultaPergunta", perguntasModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditPergunta(int idPergunta)
        {
            var perguntaDto = await _perguntaApplicationService.GetPerguntaByIdAsync(idPergunta);
            if (perguntaDto == null)
            {
                return NotFound();
            }

            var perguntaModel = new PerguntaModel
            {
                IdPergunta = perguntaDto.IdPergunta,
                IdLevel = perguntaDto.IdLevel,
                Texto = perguntaDto.Texto,
                TipoPergunta = perguntaDto.TipoPergunta
            };

            await FillLevelsViewBagAsync();
            PreencherTiposPerguntaViewBag();
            return View("EditarPergunta", perguntaModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPergunta(PerguntaModel perguntaModel)
        {
            if (ModelState.IsValid)
            {
                var perguntaDto = new PerguntaDto
                {
                    IdPergunta = perguntaModel.IdPergunta,
                    IdLevel = perguntaModel.IdLevel,
                    Texto = perguntaModel.Texto,
                    TipoPergunta = perguntaModel.TipoPergunta
                };

                await _perguntaApplicationService.UpdatePerguntaAsync(perguntaDto);
                return RedirectToAction("ConsultaPergunta");
            }

            await FillLevelsViewBagAsync();
            PreencherTiposPerguntaViewBag();
            return View("EditarPergunta", perguntaModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePergunta(int idPergunta)
        {
            await _perguntaApplicationService.DeletePerguntaAsync(idPergunta);
            return RedirectToAction("ConsultaPergunta");
        }
    }
}
