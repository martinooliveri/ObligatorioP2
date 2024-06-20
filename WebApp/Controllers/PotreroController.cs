using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PotreroController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        // GET: PotreroController
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("loggedUserRole") == null ||
                HttpContext.Session.GetString("loggedUserEmail") == null ||
                HttpContext.Session.GetString("loggedUserRole") != "Capataz")
            {
                return RedirectToAction("Logout", "Home");
            }
            IEnumerable<Potrero> potrerosOrdenados = s.GetPotrerosOrdenadosPorCapacidadYCantidad(); 
            return View(potrerosOrdenados);
        }
    }
}
