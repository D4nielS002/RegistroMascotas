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
        public DbSet<Actividad> Actividad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //permite cargar la relacion 
            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Contacto)
                .WithMany()
                .HasForeignKey(a => a.ContactoId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }

    }
}
