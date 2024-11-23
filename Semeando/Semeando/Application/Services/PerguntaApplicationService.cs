using Semeando.Application.Dtos;
using Semeando.Application.Interfaces;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Application.Services
{
    public class PerguntaApplicationService : IPerguntaApplicationService
    {
        private readonly IPerguntaRepository _perguntaRepository;

        public PerguntaApplicationService(IPerguntaRepository perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;
        }

        public async Task CreatePerguntaAsync(PerguntaDto perguntaDto)
        {
            var perguntaEntity = new PerguntaEntity
            {
                IdLevel = perguntaDto.IdLevel,
                Texto = perguntaDto.Texto,
                TipoPergunta = perguntaDto.TipoPergunta
            };

            await _perguntaRepository.CreatePerguntaAsync(perguntaEntity);
        }

        public async Task UpdatePerguntaAsync(PerguntaDto perguntaDto)
        {
            var perguntaEntity = new PerguntaEntity
            {
                IdPergunta = perguntaDto.IdPergunta,
                IdLevel = perguntaDto.IdLevel,
                Texto = perguntaDto.Texto,
                TipoPergunta = perguntaDto.TipoPergunta
            };

            await _perguntaRepository.UpdatePerguntaAsync(perguntaEntity);
        }

        public async Task DeletePerguntaAsync(int id)
        {
            await _perguntaRepository.DeletePerguntaAsync(id);
        }

        public async Task<IEnumerable<PerguntaDto>> GetAllPerguntasByLevelIdAsync(int idLevel)
        {
            var perguntas = await _perguntaRepository.GetAllPerguntasByLevelIdAsync(idLevel);

            return perguntas.Select(p => new PerguntaDto
            {
                IdPergunta = p.IdPergunta,
                IdLevel = p.IdLevel,
                Texto = p.Texto,
                TipoPergunta = p.TipoPergunta
            });
        }

        public async Task<IEnumerable<PerguntaDto>> GetAllPerguntasAsync()
        {
            var perguntas = await _perguntaRepository.GetAllPerguntasAsync();

            return perguntas.Select(p => new PerguntaDto
            {
                IdPergunta = p.IdPergunta,
                IdLevel = p.IdLevel,
                Texto = p.Texto,
                TipoPergunta = p.TipoPergunta
            });
        }

        public async Task<PerguntaDto> GetPerguntaByIdAsync(int id)
        {
            var pergunta = await _perguntaRepository.GetPerguntaByIdAsync(id);

            return pergunta == null ? null : new PerguntaDto
            {
                IdPergunta = pergunta.IdPergunta,
                IdLevel = pergunta.IdLevel,
                Texto = pergunta.Texto,
                TipoPergunta = pergunta.TipoPergunta
            };
        }
    }
}

