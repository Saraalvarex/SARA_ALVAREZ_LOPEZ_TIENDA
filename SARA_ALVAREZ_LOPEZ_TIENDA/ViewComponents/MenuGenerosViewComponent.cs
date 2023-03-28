using Microsoft.AspNetCore.Mvc;
using SARA_ALVAREZ_LOPEZ_TIENDA.Models;
using SARA_ALVAREZ_LOPEZ_TIENDA.Repositories;

namespace SARA_ALVAREZ_LOPEZ_TIENDA.ViewComponents
{
    public class MenuGenerosViewComponent: ViewComponent
    {
        private RepositoryLibros repo;

        public MenuGenerosViewComponent(RepositoryLibros repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = await this.repo.GetGeneros();
            return View(generos);
        }
    }
}
