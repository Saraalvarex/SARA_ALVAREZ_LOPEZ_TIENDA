using Microsoft.AspNetCore.Mvc;
using SARA_ALVAREZ_LOPEZ_TIENDA.Models;
using SARA_ALVAREZ_LOPEZ_TIENDA.Repositories;
using System.Diagnostics;

namespace SARA_ALVAREZ_LOPEZ_TIENDA.Controllers
{
    public class HomeController : Controller
    {
        private RepositoryLibros repo;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, RepositoryLibros repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public async Task<IActionResult> Index(int? idgenero)
        {
            if (idgenero != null)
            {
                List<Libro> libros = await this.repo.GetLibrosGenero(idgenero.Value);
                return View(libros);
            } else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}