using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        private readonly ILogger<HomeController> _logger;
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
                HttpContext.Session.SetString("loggedUserID", value: e.Id.ToString());
                return RedirectToAction("Perfil", "Empleado", new { id = e.Id });
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

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Peon p)
        {
            try
            {
                s.ValidarEmail(p.Email);
                s.AltaEmpleado(p);
                ViewBag.MessageSuccess = "Registro exitoso, ya puede ingresar al sistema";
            }
            catch (Exception e)
            {
                ViewBag.MessageError = e.Message;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
