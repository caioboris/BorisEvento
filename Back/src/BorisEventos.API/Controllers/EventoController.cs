using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BorisEventos.API.Data;
using BorisEventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BorisEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]{
            new Evento(){
                EventoId = 1,
                Tema = "Angular",
                Local = "São Paulo",
                Lote = "1° Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImageUrl = "Photo2.png"
            },
            new Evento(){
                EventoId = 2,
                Tema = ".NET",
                Local = "São Paulo",
                Lote = "1° Lote",
                QtdPessoas = 100,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImageUrl = "Photo1.png"
            }
        };
        private readonly DataContext _context;
        public EventoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context
            .Eventos
            .FirstOrDefault(evento => evento.EventoId == id);
        }

    }
}
