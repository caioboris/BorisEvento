using System.Linq;
using System.Threading.Tasks;
using BorisEventos.Domain;
using BorisEventos.Persistence.Contextos;
using BorisEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace BorisEventos.Persistence
{
    public class EventoPersistence : IEventoPersist
    {

    private readonly BorisEventosContext _context;

        public EventoPersistence(BorisEventosContext context)
        {
            _context = context;
        }



        public async Task<Evento[]> GetEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lote)
                .Include(e => e.RedesSociais);


            if(includePalestrante)
            {
                query = query
                    .Include(e=> e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lote)
                .Include(e => e.RedesSociais);


            if(includePalestrante)
            {
                query = query
                    .Include(e=> e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            
            query = query.OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));


            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int Eventoid, bool includePalestrante)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lote)
                .Include(e => e.RedesSociais);


            if(includePalestrante)
            {
                query = query
                    .Include(e=> e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            
            query = query.OrderBy(e => e.Id)
                .Where(e => e.Id == Eventoid);


            return await query.FirstOrDefaultAsync();
        }
        
    }
}