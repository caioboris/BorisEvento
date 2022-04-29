using System.Threading.Tasks;
using BorisEventos.Domain;

namespace BorisEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {

         Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrante);
         Task<Evento[]> GetEventosAsync(bool includePalestrante);
         Task<Evento> GetEventoByIdAsync(int Eventoid, bool includePalestrante);

     }
}