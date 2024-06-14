using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Sistema s = Sistema.GetInstancia();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasenia) 
        {
            Empleado? e = s.GetEmpleadoPorEmail(email);
            if (e != null && s.LoginValido(e, email, contrasenia))
            {
                HttpContext.Session.SetString("loggedUserEmail", email);
                HttpContext.Session.SetString("loggedUserPass", contrasenia);
                HttpContext.Session.SetString("loggedUserRole", e.GetTipo());
                return RedirectToAction("Perfil", new { id = e.Id });
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, revise los datos e intente nuevamente.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Perfil(int id)
        {
            if(HttpContext.Session.GetString("loggedUserEmail") == null)
            {
                return RedirectToAction("Login");
            }
            Empleado? e = s.GetEmpleadoPorId(id);
            return View(e);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
