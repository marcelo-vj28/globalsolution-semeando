using Semeando.Application.Dtos;
using Semeando.Application.Interfaces;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Application.Services
{
    public class LevelApplicationService : ILevelApplicationService
    {
        private readonly ILevelRepository _levelRepository;

        public LevelApplicationService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public async Task<LevelDto> GetLevelByIdAsync(int id)
        {
            var levelEntity = await _levelRepository.GetLevelByIdAsync(id);
            if (levelEntity == null) return null;

            return new LevelDto
            {
                IdLevel = levelEntity.IdLevel,
                Titulo = levelEntity.Titulo,
                Descricao = levelEntity.Descricao,
                Dificuldade = levelEntity.Dificuldade
            };
        }

        public async Task<IEnumerable<LevelDto>> GetAllLevelsAsync()
        {
            var levels = await _levelRepository.GetAllLevelsAsync();

            return levels.Select(level => new LevelDto
            {
                IdLevel = level.IdLevel,
                Titulo = level.Titulo,
                Descricao = level.Descricao,
                Dificuldade = level.Dificuldade
            });
        }

        public async Task CreateLevelAsync(LevelDto levelDto)
        {
            var levelEntity = new LevelEntity
            {
                Titulo = levelDto.Titulo,
                Descricao = levelDto.Descricao,
                Dificuldade = levelDto.Dificuldade
            };

            await _levelRepository.CreateLevelAsync(levelEntity);
        }

        public async Task UpdateLevelAsync(LevelDto levelDto)
        {
            var levelEntity = new LevelEntity
            {
                IdLevel = levelDto.IdLevel,
                Titulo = levelDto.Titulo,
                Descricao = levelDto.Descricao,
                Dificuldade = levelDto.Dificuldade
            };

            await _levelRepository.UpdateLevelAsync(levelEntity);
        }

        public async Task DeleteLevelAsync(int id)
        {
            await _levelRepository.DeleteLevelAsync(id);
        }
    }
}

