using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AnimalController : Controller
    {
        private Sistema s = Sistema.GetInstancia();

        public IActionResult Listado()
        {
            return View(s.GetAnimales());
        }
    }
}
