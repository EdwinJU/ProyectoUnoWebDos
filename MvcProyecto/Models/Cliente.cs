using System;

namespace MvcProyecto.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int CedulaJuridica { get; set; }
        public string PaginaWeb { get; set; }
        public string DireccionFisica{ get; set; }
        public int NumeroTelefono { get; set; }
        public string Sector { get; set; }


    }
}