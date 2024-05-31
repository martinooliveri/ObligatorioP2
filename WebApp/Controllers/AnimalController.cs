using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AnimalController : Controller
    {
        private Sistema s = Sistema.GetInstancia();

        public IActionResult Listado()
        {
            List<Animal> a = s.GetAnimales();
            if(a.Count > 0) 
            {
                return View(a);
            }
            return View();
        }
    }
}
