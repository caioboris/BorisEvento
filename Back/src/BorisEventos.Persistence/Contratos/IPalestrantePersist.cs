using System.Threading.Tasks;
using BorisEventos.Domain;

namespace BorisEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
         Task<Palestrante[]> GetPalestrantesByNomeAsync(string tema, bool includeEvento);
         Task<Palestrante[]> GetPalestrantesAsync(bool includeEvento);
         Task<Palestrante> GetPalestranteByIdAsync(int Palestranteid, bool includeEvento);
     }
}