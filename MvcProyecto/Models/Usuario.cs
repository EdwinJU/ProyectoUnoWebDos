using System;

namespace MvcProyecto.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido {get; set;}
        public string Username { get; set; }
        public string Password{ get; set; }
        public string TipoUsuario {get; set;}


    }
}