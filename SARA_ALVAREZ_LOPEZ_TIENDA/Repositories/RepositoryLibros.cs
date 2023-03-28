using Microsoft.EntityFrameworkCore;
using SARA_ALVAREZ_LOPEZ_TIENDA.Data;
using SARA_ALVAREZ_LOPEZ_TIENDA.Models;

namespace SARA_ALVAREZ_LOPEZ_TIENDA.Repositories
{
    public class RepositoryLibros
    {
        private LibrosContext context;
        public RepositoryLibros(LibrosContext context)
        {
            this.context = context;
        }
        public async Task<List<Genero>> GetGeneros()
        {
            return await this.context.Generos.ToListAsync();
        }
        public async Task<List<Libro>> GetLibrosGenero(int idgenero)
        {
            var libros = from datos in this.context.Libros
                         where datos.IdGenero == idgenero
                         select datos;
            return await libros.ToListAsync();
        }
        public async Task<List<Libro>> GetLibros()
        {
            return await this.context.Libros.ToListAsync();
        }
    }
}
