using Microsoft.EntityFrameworkCore;

namespace  MvcProyecto.Models
{
    public class MvcProyectoContext : DbContext
    {
        public MvcProyectoContext (DbContextOptions<MvcProyectoContext> options)
            : base(options)
        {
        }

        public DbSet<MvcProyecto.Models.Usuario> Usuario { get; set; }

        public DbSet<MvcProyecto.Models.Cliente> Cliente { get; set; }

        public DbSet<MvcProyecto.Models.Contacto> Contacto { get; set; }

        public DbSet<MvcProyecto.Models.Reunion> Reunion { get; set; }

        public DbSet<MvcProyecto.Models.ReporteProblema> ReporteProblema { get; set; }
    }
}