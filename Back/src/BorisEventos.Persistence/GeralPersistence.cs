using System.Linq;
using System.Threading.Tasks;
using BorisEventos.Domain;
using BorisEventos.Persistence.Contextos;
using BorisEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace BorisEventos.Persistence
{
    public class GeralPersistence : IGeralPersist
    {
        private readonly BorisEventosContext _context;

        public GeralPersistence(BorisEventosContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        
    }
}