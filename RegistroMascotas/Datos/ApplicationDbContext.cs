using Microsoft.EntityFrameworkCore;
using RegistroMascotas.Models;

namespace RegistroMascotas.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }
    }
}
