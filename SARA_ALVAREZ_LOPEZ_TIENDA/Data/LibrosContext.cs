using Microsoft.EntityFrameworkCore;
using SARA_ALVAREZ_LOPEZ_TIENDA.Models;

namespace SARA_ALVAREZ_LOPEZ_TIENDA.Data
{
    public class LibrosContext:DbContext {
        public LibrosContext(DbContextOptions<LibrosContext> options) : base(options) { }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Genero> Generos { get; set; }

    }
}
