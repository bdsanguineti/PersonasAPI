using Cetap.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
            
        }
        
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Provincia> Provincias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Provincias
            modelBuilder.Entity<Provincia>().HasData(
                new Provincia { Id = 1, Nombre = "Buenos Aires" },
                new Provincia { Id = 2, Nombre = "Córdoba" },
                new Provincia { Id = 3, Nombre = "Santa Fe" }
            );

            // Seed Personas
            modelBuilder.Entity<Persona>().HasData(
                new Persona
                {
                    Id = 1,
                    Nombre = "Juani",
                    Apellido = "Perez",
                    ProvinciaId = 1,
                    DNI = "12345678",
                    Telefono = "3416109022",
                    FechaAlta = DateTime.Now,
                    FechaModificacion = DateTime.Now
                },
                new Persona
                {
                    Id = 2,
                    Nombre = "Ana Laura",
                    Apellido = "Garcia",
                    ProvinciaId = 2,
                    DNI = "87654321",
                    Telefono = "987654321",
                    FechaAlta = DateTime.Now,
                    FechaModificacion = DateTime.Now
                }
            );
        }
    }
}
