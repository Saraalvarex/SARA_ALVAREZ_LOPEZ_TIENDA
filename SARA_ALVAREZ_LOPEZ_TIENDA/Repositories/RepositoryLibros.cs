using Microsoft.Data.SqlClient;
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
        private int GetMaxIdPedido()
        {
            if (this.context.Pedidos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Pedidos.Max(x => x.IdPedido) + 1;
            }
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
        public async Task<LibrosPaginados> GetLibrosPagAsync(int posicion)
        {
            List<Libro> libros = await this.GetLibros();
            int numregistros = libros.Count;

            List<Libro> listalibrospaginados = libros.Skip(posicion).Take(3).ToList();

            LibrosPaginados librosPaginados = new LibrosPaginados
            {
                Libros = listalibrospaginados,
                NumRegistros = numregistros
            };

            return librosPaginados;
        }
        public async Task<Libro> GetLibro(int idlibro)
        {
            return await this.context.Libros.FirstOrDefaultAsync(i => i.IdLibro == idlibro);

        }
        public async Task InsertPedido(int idlibro, int idusuario)
        {
            Pedido pedido = new Pedido
            {
                IdPedido = this.GetMaxIdPedido(),
                IdFactura = 1,
                Fecha = DateTime.Now,
                IdLibro = idlibro,
                IdUsuario = idusuario,
                Cantidad = 1,
            };
            this.context.Pedidos.Add(pedido);
            this.context.SaveChanges();
        }
        public async Task<List<Pedido>> GetPedidos(int idusuario)
        {
            var pedidos = from datos in this.context.Pedidos
                         where datos.IdUsuario == idusuario
                         select datos;
            return await pedidos.ToListAsync();
        }

        public async Task<Usuario> LoginUsuarioAsync(string username, string pass)
        {
            Usuario user = await this.context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == username);
            if (user == null)
            {
                return null;
            }
            else
            {
                if (user.Pass == pass)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
