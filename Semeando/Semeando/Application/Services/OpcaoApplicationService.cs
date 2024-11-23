using Semeando.Application.Dtos;
using Semeando.Application.Interfaces;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Application.Services
{
    public class OpcaoApplicationService : IOpcaoApplicationService
    {
        private readonly IOpcaoRepository _opcaoRepository;

        public OpcaoApplicationService(IOpcaoRepository opcaoRepository)
        {
            _opcaoRepository = opcaoRepository;
        }

        public async Task<OpcaoDto> GetOpcaoByIdAsync(int idOpcao)
        {
            var opcaoEntity = await _opcaoRepository.GetOpcaoByIdAsync(idOpcao);

            if (opcaoEntity == null)
                return null;

            return new OpcaoDto
            {
                IdOpcao = opcaoEntity.IdOpcao,
                IdPergunta = opcaoEntity.IdPergunta,
                Texto = opcaoEntity.Texto,
                OpcaoCorreta = opcaoEntity.OpcaoCorreta
            };
        }

        public async Task<IEnumerable<OpcaoDto>> GetAllOpcoesAsync()
        {
            var opcoes = await _opcaoRepository.GetAllOpcoesAsync();
            return opcoes.Select(o => new OpcaoDto
            {
                IdOpcao = o.IdOpcao,
                IdPergunta = o.IdPergunta,
                Texto = o.Texto,
                OpcaoCorreta = o.OpcaoCorreta
            });
        }

        public async Task<IEnumerable<OpcaoDto>> GetAllOpcoesByPerguntaIdAsync(int idPergunta)
        {
            var opcoes = await _opcaoRepository.GetAllOpcoesByPerguntaIdAsync(idPergunta);
            return opcoes.Select(o => new OpcaoDto
            {
                IdOpcao = o.IdOpcao,
                IdPergunta = o.IdPergunta,
                Texto = o.Texto,
                OpcaoCorreta = o.OpcaoCorreta
            });
        }

        public async Task CreateOpcaoAsync(OpcaoDto opcaoDto)
        {
            var opcaoEntity = new OpcaoEntity
            {
                IdPergunta = opcaoDto.IdPergunta,
                Texto = opcaoDto.Texto,
                OpcaoCorreta = opcaoDto.OpcaoCorreta
            };

            await _opcaoRepository.CreateOpcaoAsync(opcaoEntity);
        }

        public async Task UpdateOpcaoAsync(OpcaoDto opcaoDto)
        {
            var opcaoEntity = new OpcaoEntity
            {
                IdOpcao = opcaoDto.IdOpcao,
                IdPergunta = opcaoDto.IdPergunta,
                Texto = opcaoDto.Texto,
                OpcaoCorreta = opcaoDto.OpcaoCorreta
            };

            await _opcaoRepository.UpdateOpcaoAsync(opcaoEntity);
        }

        public async Task DeleteOpcaoAsync(int idOpcao)
        {
            await _opcaoRepository.DeleteOpcaoAsync(idOpcao);
        }
    }
}



