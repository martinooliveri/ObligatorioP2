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
        public IActionResult PeonesListado()
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
        public IActionResult Tareas(int id)
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
        public IActionResult AsignarTarea(int id)
        {
            if (HttpContext.Session.GetString("loggedUserRole") == null ||
                HttpContext.Session.GetString("loggedUserEmail") == null ||
                HttpContext.Session.GetString("loggedUserRole") != "Capataz" ||
                id == 0)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                Peon? p = s.GetPeonPorId(id);
                if (p == null) throw new Exception("Peon no encontrado");
                ViewBag.NombrePeon = p.Nombre;
                ViewBag.PeonId = p.Id;
            }
            catch (Exception e)
            {
                ViewBag.MessageError = e.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult AsignarTarea([FromForm] Tarea t, [FromForm] int PeonId) //este detalle del [FromForm] permite recibir un objeto con el model binding y tambien recibir otro parametro a la vez
        {
            if (HttpContext.Session.GetString("loggedUserRole") == null ||
                HttpContext.Session.GetString("loggedUserEmail") == null ||
                HttpContext.Session.GetString("loggedUserRole") != "Capataz")
            {
                return RedirectToAction("Logout", "Home");
            }

            try
            {
                Peon? p = s.GetPeonPorId(PeonId);
                if (p == null) throw new Exception("Peon no encontrado");
                ViewBag.NombrePeon = p.Nombre;
                ViewBag.PeonId = p.Id;
                s.AddTareaToPeon(t, p);
                ViewBag.MessageExito = $"Tarea #{t.Id} asignada correctamente";
            }
            catch (Exception e)
            {
                ViewBag.MessageError = e.Message;
            }

            return View();
        }

        [HttpGet]
        public IActionResult CerrarTarea(int id)
        {
            if (HttpContext.Session.GetString("loggedUserRole") == null ||
                HttpContext.Session.GetString("loggedUserEmail") == null ||
                HttpContext.Session.GetString("loggedUserRole") != "Peon")
            {
                return RedirectToAction("Logout", "Home");
            }
            Peon? p = s.GetPeonPorId(id);
            if (p != null)
            {
                ViewBag.IdPeon = p.Id;
                IEnumerable<Tarea> tareas = p.GetTareasPendientes();
                return View(tareas);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CerrarTarea(int id, int idTarea, string comentario)
        {
            if (HttpContext.Session.GetString("loggedUserRole") == null ||
                HttpContext.Session.GetString("loggedUserEmail") == null ||
                HttpContext.Session.GetString("loggedUserRole") != "Peon")
            {
                return RedirectToAction("Logout", "Home");
            }
            List<Tarea> tareas = new List<Tarea>();
            try
            {
                Tarea? t;
                Peon? p = s.GetPeonPorId(id);
                ViewBag.IdPeon = p.Id;
                tareas = p.GetTareasPendientes();
                
                if (p == null) throw new Exception("No se encontro el peon.");
                t = p.GetTareaPorId(idTarea);
                if (t == null) throw new Exception("Debe seleccionar una tarea");
                t.CerrarTarea(comentario);
                ViewBag.MessageExito = $"Tarea #{t.Id} cerrada correctamente";
            }
            catch (Exception e)
            {
                ViewBag.MessageError = e.Message;
            }
            return View(tareas);
            
        }
    }
}
