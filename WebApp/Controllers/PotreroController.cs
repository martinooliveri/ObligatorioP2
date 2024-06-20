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
            IEnumerable<Potrero> potrerosOrdenados = s.GetPotrerosOrdenadosPorCapacidadYCantidad(); 
            return View(potrerosOrdenados);
        }
    }
}
