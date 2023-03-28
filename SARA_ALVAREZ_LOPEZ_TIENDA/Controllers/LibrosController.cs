using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SARA_ALVAREZ_LOPEZ_TIENDA.Extensions;
using SARA_ALVAREZ_LOPEZ_TIENDA.Filters;
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

        //BOTON
        public IActionResult AddCarrito(int idlibro)
        {
            List<int> idslibros = HttpContext.Session.GetObject<List<int>>("CARRITO");
           
            //SI CARRITO ESTA EN SESION...
            if (idslibros != null)
            {
                idslibros.Add(idlibro);
                HttpContext.Session.SetObject("CARRITO", idslibros);
            }
            else
            {
                //SINO CREO CARRITO EN SESSION
                List<int> newidslibros = new List<int> { idlibro };
                HttpContext.Session.SetObject("CARRITO", newidslibros);
            }
            return RedirectToAction("Index");
        }

        [AuthorizeUsers]
        public async Task<IActionResult> Carrito()
        {
            List<int> idslibros = HttpContext.Session.GetObject<List<int>>("CARRITO");
            List<Libro> libros = new List<Libro>();
            if (idslibros != null)
            {
                foreach (int id in idslibros)
                {
                    Libro libro = await this.repo.GetLibro(id);
                    libros.Add(libro);
                }
            }
            return View();
        }
    }
}
