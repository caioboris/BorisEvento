using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BorisEventos.Persistence;
using BorisEventos.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BorisEventos.Persistence.Contextos;
using BorisEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace BorisEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if(eventos == null) return NotFound("Nenhum evento encontrado.");

                return Ok(eventos);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar eventos. Erro: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          try
          {
              var evento = await _eventoService.GetEventoByIdAsync(id,true);
              if(evento == null) return NotFound("Evento não encontrado.");

              return Ok(evento);
          }
          catch (Exception e)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao recuperar evento. Erro: {e.Message}");
          }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
          try
          {
              var eventos = await _eventoService.GetEventosByTemaAsync(tema,true);
              if(eventos == null) return NotFound("Eventos não encontrados.");

              return Ok(eventos);
          }
          catch (Exception e)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao recuperar eventos. Erro: {e.Message}");
          }
        }

        [HttpPost]
        public async Task<IActionResult> AddEvento(Evento model){
          try
          {
              var evento = await _eventoService.AddEventos(model);
              if(evento == null) return BadRequest("Erro ao adicionar evento.");

              return Ok(evento);
          }
          catch (Exception e)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao adicionar evento. Erro: {e.Message}");
          }
        }

        [HttpPut("{id}")]
       public async Task<IActionResult> EditEvento(int id, Evento model){
          try
          {
              var evento = await _eventoService.UpdateEventos(id, model);
              if(evento == null) return BadRequest("Erro ao adicionar evento.");

              return Ok(evento);
          }
          catch (Exception e)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao editar evento. Erro: {e.Message}");
          }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id){

            try
            {
                return await _eventoService.DeleteEvento(id) ?
                    Ok("Evento deletado."):
                    BadRequest("Erro ao deletar evento"); 

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao deletar evento. Erro: {e.Message}");                
            }

        }

    }
}
