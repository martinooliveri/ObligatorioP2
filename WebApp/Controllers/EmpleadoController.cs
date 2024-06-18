using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EmpleadoController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        // GET: EmpleadoController
        [HttpGet]
        public ActionResult ListadoPeones()
        {
            if (HttpContext.Session.GetString("loggedUserEmail") == null ||
                HttpContext.Session.GetString("loggedUserRole") != "Capataz")
            {
                return RedirectToAction("Logout", "Home");
            }
            List<Peon> p = s.GetPeones();
            if(p.Count > 0)
            {
                return View(p);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Perfil(int id)
        {
            if (HttpContext.Session.GetString("loggedUserEmail") == null || 
                HttpContext.Session.GetString("loggedUserID") != id.ToString())
            {
                return RedirectToAction("Logout", "Home");
            }
            Empleado? e = s.GetEmpleadoPorId(id);
            return View(e);
        }

        [HttpGet]
        public ActionResult Tareas(int id)
        {
            if (HttpContext.Session.GetString("loggedUserEmail") == null ||
                HttpContext.Session.GetString("loggedUserID") != id.ToString() || 
                HttpContext.Session.GetString("loggedUserRole") != "Capataz")
            {
                return RedirectToAction("Logout", "Home");
            }

            Peon? p = s.GetPeon(id);
            if (p == null) return View();
            ViewBag.NombrePeon = p.Nombre;
            IEnumerable<Tarea> tareas = p.GetTareas();
            return View(tareas);
        }
    }
}
