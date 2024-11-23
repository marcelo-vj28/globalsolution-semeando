using Microsoft.EntityFrameworkCore;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using Semeando.Infrastructure.Data.AppData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Infrastructure.Data.Repositories
{
    public class RespostaRepository : IRespostaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RespostaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RespostaEntity>> GetAllRespostasAsync()
        {
            return await _dbContext.Respostas
                .Include(r => r.Pergunta)
                .Include(r => r.Opcao)
                .ToListAsync();
        }

        public async Task<RespostaEntity> GetRespostaByIdAsync(int id)
        {
            return await _dbContext.Respostas
                .Where(r => r.IdResposta == id)
                .Include(r => r.Pergunta)
                .Include(r => r.Opcao)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RespostaEntity>> GetAllRespostasByUsuarioIdAsync(int idUsuario)
        {
            return await _dbContext.Respostas
                .Where(r => r.IdUsuario == idUsuario)
                .Include(r => r.Pergunta)
                .Include(r => r.Opcao)
                .ToListAsync();
        }

        public async Task CreateRespostaAsync(RespostaEntity respostaEntity)
        {
            await _dbContext.Respostas.AddAsync(respostaEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRespostaAsync(RespostaEntity respostaEntity)
        {
            _dbContext.Respostas.Update(respostaEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRespostaAsync(int id)
        {
            var respostaEntity = await GetRespostaByIdAsync(id);
            if (respostaEntity != null)
            {
                _dbContext.Respostas.Remove(respostaEntity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
