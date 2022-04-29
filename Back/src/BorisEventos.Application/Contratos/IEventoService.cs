using System.Threading.Tasks;
using BorisEventos.Domain;

namespace BorisEventos.Application.Contratos
{
    public interface IEventoService
    {
         Task<Evento> AddEventos(Evento model);
         Task<Evento> UpdateEventos(int EventoId, Evento model);
         Task<bool> DeleteEvento(int EventoId);

         Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false);

         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false);
         Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrante = false);

     }
}