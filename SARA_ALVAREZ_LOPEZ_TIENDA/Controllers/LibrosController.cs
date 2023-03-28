using Microsoft.AspNetCore.Mvc;
using SARA_ALVAREZ_LOPEZ_TIENDA.Models;
using SARA_ALVAREZ_LOPEZ_TIENDA.Repositories;

namespace SARA_ALVAREZ_LOPEZ_TIENDA.Controllers
{
    public class LibrosController : Controller
    {
        private RepositoryLibros repo;
        public LibrosController(RepositoryLibros repo)
        { 
            this.repo = repo; 
        }

        public async Task<IActionResult> Index(int? posicion)
        {
            //List<Libro> libros = await this.repo.GetLibros();
            //return View(libros);
            posicion = (posicion == null) ? 0 : posicion.Value;
            LibrosPaginados librosPaginados = await this.repo.GetLibrosPagAsync(posicion.Value);
            ViewData["REGISTROS"] = librosPaginados.NumRegistros;
            return View(librosPaginados.Libros);
        }

        public async Task<IActionResult> Details(int idlibro)
        {
            Libro libro = await this.repo.GetLibro(idlibro);
            return View(libro);
        }
    }
}
