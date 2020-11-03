using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class AyudaContext: DbContext
    {
        public AyudaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; } 
        public DbSet<Donacion> Donaciones { get; set; }
        
    }
}