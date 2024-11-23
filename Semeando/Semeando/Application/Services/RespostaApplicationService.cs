using Semeando.Application.Dtos;
using Semeando.Application.Interfaces;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Application.Services
{
    public class RespostaApplicationService : IRespostaApplicationService
    {
        private readonly IRespostaRepository _respostaRepository;

        public RespostaApplicationService(IRespostaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public async Task CreateRespostaAsync(RespostaDto respostaDto)
        {
            var respostaEntity = new RespostaEntity
            {
                IdUsuario = respostaDto.IdUsuario,
                IdPergunta = respostaDto.IdPergunta,
                OpcaoEscolhida = respostaDto.OpcaoEscolhida
            };

            await _respostaRepository.CreateRespostaAsync(respostaEntity);
        }

        public async Task UpdateRespostaAsync(RespostaDto respostaDto)
        {
            var respostaEntity = new RespostaEntity
            {
                IdResposta = respostaDto.IdResposta,
                IdUsuario = respostaDto.IdUsuario,
                IdPergunta = respostaDto.IdPergunta,
                OpcaoEscolhida = respostaDto.OpcaoEscolhida
            };

            await _respostaRepository.UpdateRespostaAsync(respostaEntity);
        }

        public async Task DeleteRespostaAsync(int id)
        {
            await _respostaRepository.DeleteRespostaAsync(id);
        }

        public async Task<IEnumerable<RespostaDto>> GetAllRespostasByUsuarioIdAsync(int idUsuario)
        {
            var respostaEntities = await _respostaRepository.GetAllRespostasByUsuarioIdAsync(idUsuario);

            return respostaEntities.Select(respostaEntity => new RespostaDto
            {
                IdResposta = respostaEntity.IdResposta,
                IdUsuario = respostaEntity.IdUsuario,
                IdPergunta = respostaEntity.IdPergunta,
                OpcaoEscolhida = respostaEntity.OpcaoEscolhida
            }).ToList();
        }

        public async Task<IEnumerable<RespostaDto>> GetAllRespostasAsync()
        {
            var respostaEntities = await _respostaRepository.GetAllRespostasAsync();

            return respostaEntities.Select(respostaEntity => new RespostaDto
            {
                IdResposta = respostaEntity.IdResposta,
                IdUsuario = respostaEntity.IdUsuario,
                IdPergunta = respostaEntity.IdPergunta,
                OpcaoEscolhida = respostaEntity.OpcaoEscolhida
            }).ToList();
        }

        public async Task<RespostaDto> GetRespostaByIdAsync(int id)
        {
            var respostaEntity = await _respostaRepository.GetRespostaByIdAsync(id);

            if (respostaEntity == null)
            {
                return null;
            }

            return new RespostaDto
            {
                IdResposta = respostaEntity.IdResposta,
                IdUsuario = respostaEntity.IdUsuario,
                IdPergunta = respostaEntity.IdPergunta,
                OpcaoEscolhida = respostaEntity.OpcaoEscolhida
            };
        }
    }
}



