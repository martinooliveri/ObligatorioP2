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
            return View(s.GetPeones());
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
            if (HttpContext.Session.GetString("loggedUserRole") == "Peon" && HttpContext.Session.GetString("loggedUserID") != id.ToString() ||
                HttpContext.Session.GetString("loggedUserEmail") == null)
            {
                return RedirectToAction("Logout", "Home");
            }

            Peon? p = s.GetPeonPorId(id);
            if (p == null) return View();
            ViewBag.NombrePeon = p.Nombre;
            IEnumerable<Tarea> tareas = p.GetTareas();
            return View(tareas);
        }

        [HttpGet]
        public ActionResult AsignarTarea(int id)
        {
            if (HttpContext.Session.GetString("loggedUserRole") == null ||
                HttpContext.Session.GetString("loggedUserEmail") == null || 
                HttpContext.Session.GetString("loggedUserRole") == "Capataz")
            {
                return RedirectToAction("Logout", "Home");
            }
            Peon? p = s.GetPeonPorId(id);
            if (p == null) return View();
            ViewBag.NombrePeon = p.Nombre;
            IEnumerable <Tarea>? tareas = s.GetTareas();
            foreach (Tarea t in tareas)
            {
                if (tareas == null) return View();
                s.AddTareaToPeon(t, p);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CerrarTarea(int id, string comentario)
        {
            IEnumerable<Tarea>? tareas = s.GetTareas(); // Asume que tienes un servicio que obtiene la tarea por ID
            if (tareas == null)
            {
                return NotFound();
            }
            foreach (Tarea t in tareas)
            {
                t.FueCompletada = true;
                t.Comentario = comentario;
                t.FechaDeCierre = DateTime.Now;
            }
            return View();
        }
    }
}
