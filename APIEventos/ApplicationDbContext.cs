using Microsoft.EntityFrameworkCore;
using APIEventos.Entidades;

namespace APIEventos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        
        }

        public DbSet<Events> Events { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Asistants> Asistants { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
