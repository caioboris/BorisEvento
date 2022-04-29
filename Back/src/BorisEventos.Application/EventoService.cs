using System;
using System.Threading.Tasks;
using BorisEventos.Application.Contratos;
using BorisEventos.Domain;
using BorisEventos.Persistence.Contratos;

namespace BorisEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                
                return null;
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }
        }
        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            var evento = _eventoPersist.GetEventoByIdAsync(eventoId,false);
            if(evento == null) return null;

            model.Id = evento.Id;

            try
            {
                _geralPersist.Update(model);

               if(await _geralPersist.SaveChangesAsync()){
                   return await _eventoPersist.GetEventoByIdAsync(model.Id,false);
               }
               return null;
            }
            catch (Exception e)
            {                  
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Evento não encontrado!");

                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangesAsync();               
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }

        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventosAsync(includePalestrante);
                if(eventos == null) return null;    
                
                return eventos;

            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId,includePalestrante);
                if(evento == null) return null;    
                
                return evento;

            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventosByTemaAsync(tema,includePalestrante);
                if(eventos == null) return null;    
                
                return eventos;

            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

    }
}