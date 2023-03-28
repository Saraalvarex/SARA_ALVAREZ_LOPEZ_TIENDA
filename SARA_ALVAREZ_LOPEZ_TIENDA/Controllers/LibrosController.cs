using Microsoft.AspNetCore.Mvc;

namespace SARA_ALVAREZ_LOPEZ_TIENDA.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
