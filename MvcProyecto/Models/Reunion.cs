using System;

namespace MvcProyecto.Models
{
    public class Reunion
    {
        public int ID { get; set; }
        public string TituloReunion { get; set; }
        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario usuario { get; set; }
        public Boolean EsVirtual{ get; set; }



    }
}