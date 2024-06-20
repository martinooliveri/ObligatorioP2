using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
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
                HttpContext.Session.SetString("loggedUserID", e.Id.ToString());
                return RedirectToAction("Perfil", "Empleado", new { id = e.Id });
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, revise los datos e intente nuevamente.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro([FromForm] Peon p, [FromForm] string repeticionContrasenia)
        {
            try
            {
                s.ValidarEmail(p.Email);
                if (repeticionContrasenia == null) throw new Exception("Ingrese la repeticion de contraseña");
                if (p.Contrasenia != repeticionContrasenia) throw new Exception("Las contraseñas no coinciden");
                s.AltaEmpleado(p);
                ViewBag.MessageSuccess = "Registro exitoso, ya puede ingresar al sistema";
            }
            catch (Exception e)
            {
                ViewBag.MessageError = e.Message;
            }
            return View();
        }
    }
}
