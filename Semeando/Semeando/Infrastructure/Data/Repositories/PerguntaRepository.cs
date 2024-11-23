using Microsoft.EntityFrameworkCore;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using Semeando.Infrastructure.Data.AppData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Infrastructure.Data.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {
        private readonly ApplicationDbContext _context;

        public PerguntaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PerguntaEntity>> GetAllPerguntasAsync()
        {
            return await _context.Perguntas
                .Include(p => p.Level) // Relacionamento com Level
                .ToListAsync();
        }

        public async Task<PerguntaEntity> GetPerguntaByIdAsync(int id)
        {
            return await _context.Perguntas
                .Include(p => p.Level)
                .FirstOrDefaultAsync(p => p.IdPergunta == id);
        }

        public async Task<IEnumerable<PerguntaEntity>> GetAllPerguntasByLevelIdAsync(int idLevel)
        {
            return await _context.Perguntas
                .Where(p => p.IdLevel == idLevel)
                .Include(p => p.Level)
                .ToListAsync();
        }

        public async Task CreatePerguntaAsync(PerguntaEntity perguntaEntity)
        {
            await _context.Perguntas.AddAsync(perguntaEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePerguntaAsync(PerguntaEntity perguntaEntity)
        {
            _context.Perguntas.Update(perguntaEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePerguntaAsync(int id)
        {
            var perguntaEntity = await GetPerguntaByIdAsync(id);
            if (perguntaEntity != null)
            {
                _context.Perguntas.Remove(perguntaEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

