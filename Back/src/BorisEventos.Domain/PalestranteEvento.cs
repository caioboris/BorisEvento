namespace BorisEventos.Domain
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }

        public Palestrante Palestrante { get; set; }

        public Evento Evento {get;set;}

        public int EventoId {get;set;}
    }
}