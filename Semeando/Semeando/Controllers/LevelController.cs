using Microsoft.AspNetCore.Mvc;
using Semeando.Application.Interfaces;
using Semeando.Application.Dtos;
using Semeando.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Controllers
{
    public class LevelController : Controller
    {
        private readonly ILevelApplicationService _levelApplicationService;

        public LevelController(ILevelApplicationService levelApplicationService)
        {
            _levelApplicationService = levelApplicationService;
        }

        private async Task FillViewBagAsync()
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

        [HttpGet]
        public async Task<IActionResult> CreateLevel()
        {
            await FillViewBagAsync();
            return View("CadastroLevel", new LevelModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateLevel(LevelModel levelModel)
        {
            if (ModelState.IsValid)
            {
                var levelDto = new LevelDto
                {
                    Titulo = levelModel.Titulo,
                    Descricao = levelModel.Descricao,
                    Dificuldade = levelModel.Dificuldade
                };

                await _levelApplicationService.CreateLevelAsync(levelDto);
                return RedirectToAction("ViewLevels");
            }

            await FillViewBagAsync();
            return View("CadastroLevel", levelModel);
        }

        [HttpGet]
        public async Task<IActionResult> ViewLevels()
        {
            var levelsDto = await _levelApplicationService.GetAllLevelsAsync();
            var levelsModel = levelsDto.Select(l => new LevelModel
            {
                IdLevel = l.IdLevel,
                Titulo = l.Titulo,
                Descricao = l.Descricao,
                Dificuldade = l.Dificuldade
            }).ToList();

            ViewBag.TotalLevels = levelsModel.Count;
            ViewBag.LevelsPorDificuldade = new Dictionary<string, int>
            {
                { "Fácil", levelsModel.Count(l => l.Dificuldade == "Fácil") },
                { "Médio", levelsModel.Count(l => l.Dificuldade == "Médio") },
                { "Difícil", levelsModel.Count(l => l.Dificuldade == "Difícil") }
            };

            return View("ConsultaLevel", levelsModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditLevel(int id)
        {
            var levelDto = await _levelApplicationService.GetLevelByIdAsync(id);
            if (levelDto == null) return NotFound();

            await FillViewBagAsync();

            var levelModel = new LevelModel
            {
                IdLevel = levelDto.IdLevel,
                Titulo = levelDto.Titulo,
                Descricao = levelDto.Descricao,
                Dificuldade = levelDto.Dificuldade
            };

            return View("EditarLevel", levelModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditLevel(LevelModel levelModel)
        {
            if (ModelState.IsValid)
            {
                var levelDto = new LevelDto
                {
                    IdLevel = levelModel.IdLevel,
                    Titulo = levelModel.Titulo,
                    Descricao = levelModel.Descricao,
                    Dificuldade = levelModel.Dificuldade
                };

                await _levelApplicationService.UpdateLevelAsync(levelDto);
                return RedirectToAction("ConsultaLevel");
            }

            await FillViewBagAsync();
            return View("EditarLevel", levelModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLevel(int id)
        {
            await _levelApplicationService.DeleteLevelAsync(id);
            return RedirectToAction("ConsultaLevel");
        }
    }
}

