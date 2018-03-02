using System;

namespace MvcProyecto.Models
{
    public class Contacto
    {
        public int ID { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos{ get; set; }
        public string Correo  { get; set; }
        public int NumeroTelefono { get; set; }
        public string Puesto {get; set;}


    }
}