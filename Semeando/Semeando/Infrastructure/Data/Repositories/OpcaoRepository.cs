using Microsoft.EntityFrameworkCore;
using Semeando.Domain.Entities;
using Semeando.Domain.Interfaces;
using Semeando.Infrastructure.Data.AppData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semeando.Infrastructure.Data.Repositories
{
    public class OpcaoRepository : IOpcaoRepository
    {
        private readonly ApplicationDbContext _context;

        public OpcaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpcaoEntity>> GetAllOpcoesAsync()
        {
            return await _context.Opcoes
                .Include(o => o.Pergunta)
                .ToListAsync();
        }

        public async Task<OpcaoEntity> GetOpcaoByIdAsync(int idOpcao)
        {
            return await _context.Opcoes
                .Include(o => o.Pergunta)
                .FirstOrDefaultAsync(o => o.IdOpcao == idOpcao);
        }

        public async Task<IEnumerable<OpcaoEntity>> GetAllOpcoesByPerguntaIdAsync(int idPergunta)
        {
            return await _context.Opcoes
                .Where(o => o.IdPergunta == idPergunta)
                .ToListAsync();
        }

        public async Task CreateOpcaoAsync(OpcaoEntity opcaoEntity)
        {
            await _context.Opcoes.AddAsync(opcaoEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOpcaoAsync(OpcaoEntity opcaoEntity)
        {
            _context.Opcoes.Update(opcaoEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOpcaoAsync(int idOpcao)
        {
            var opcao = await GetOpcaoByIdAsync(idOpcao);

            if (opcao != null)
            {
                _context.Opcoes.Remove(opcao);
                await _context.SaveChangesAsync();
            }
        }
    }
}

