using System;

namespace MvcProyecto.Models
{
    public class ReporteProblema
    {
        public int ID { get; set; }
        public string TituloProblema { get; set; }
        public string DetalleProblema { get; set; }

        public string QuienReporto { get; set; }
        public int ClienteId {get; set;}
        public virtual Cliente Cliente { get; set; }
        public string Estado{ get; set; }



    }
}