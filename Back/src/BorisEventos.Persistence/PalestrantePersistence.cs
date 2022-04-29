using System.Linq;
using System.Threading.Tasks;
using BorisEventos.Domain;
using BorisEventos.Persistence.Contextos;
using BorisEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace BorisEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersist
    {
        private readonly BorisEventosContext _context;

        public PalestrantePersistence(BorisEventosContext context)
        {
            _context = context;
        }


        public async Task<Palestrante[]> GetPalestrantesAsync(bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if(includeEvento){
                query.Include(p => p.PalestrantesEventos)
                .ThenInclude(p => p.Evento); 
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Palestrante[]> GetPalestrantesByNomeAsync(string nome, bool includeEvento)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if(includeEvento){
                query.Include(p => p.PalestrantesEventos)
                .ThenInclude(p => p.Evento); 
            }

            query = query.OrderBy(p => p.Id)
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteid, bool includeEvento)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if(includeEvento){
                query.Include(p => p.PalestrantesEventos)
                .ThenInclude(p => p.Evento); 
            }

            query = query.OrderBy(p => p.Id)
                .Where(p => p.Id == palestranteid);

            return await query.FirstOrDefaultAsync();
        }

        
    }
}