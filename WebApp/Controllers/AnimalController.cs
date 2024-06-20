using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AnimalController : Controller
    {

        private Sistema s = Sistema.GetInstancia();

        [HttpGet]
        public IActionResult LibresListado()
        {
            List<Animal> a = s.GetAnimalesLibres();
            return View(a);
        }

        [HttpGet]
        public IActionResult AltaBovino()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AltaBovino(Bovino b)
        {
            try
            {
                s.AltaAnimal(b);
                ViewBag.Message = "Alta de bovino exitosa";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Vacunar()
        {
            List<Vacuna> vacunas = s.GetVacunas();
            return View(vacunas);
        }
        [HttpPost]
        public IActionResult Vacunar(string idCaravana, int idVacuna)
        {
            try
            {
                Animal? a = s.GetAnimalPorNumeroCaravana(idCaravana);
                Vacuna? v = s.GetVacunaPorId(idVacuna);
                if (a == null) throw new Exception("No se encontro el animal. ");
                if (v == null) throw new Exception("No se encontro la vacuna. ");
                a.VacunarAnimal(v);
                ViewBag.Message = "Vacunacion registrada exitosamente. ";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message + "Revise los datos e intentelo nuevamente. ";
            }
            List<Vacuna> vacunas = s.GetVacunas();
            return View(vacunas);
        }

        [HttpGet]
        public IActionResult AsignarPotrero(int id)
        {   
            Animal? a = s.GetAnimalPorId(id);
            if (a != null) ViewBag.NumeroCaravana = a.NumeroCaravana;
            return View(s.GetPotreros());
        }
        [HttpPost]
        public IActionResult AsignarPotrero(string idCaravana, int idPotrero)
        {
            try
            {
                Animal? a = s.GetAnimalPorNumeroCaravana(idCaravana);
                Potrero? p = s.GetPotreroPorId(idPotrero);
                if (a == null) throw new Exception("No se encontro el animal. ");
                if (p == null) throw new Exception("No se encontro el potrero. ");
                s.AddAnimalToPotrero( a , p );
                ViewBag.Message = $"{a.GetTipo()} con caravana {idCaravana} asignado al potrero #{idPotrero}.";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message + " // Revise los datos e intentelo nuevamente. ";
            }
            IEnumerable<Potrero> potreros = s.GetPotreros();
            return View(potreros);
        }

        [HttpGet]
        public IActionResult ListadoFiltrado()
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult ListadoFiltrado(string tipoAnimal, double pesoAnimal)
        {
            if ((tipoAnimal != "Bovino" && tipoAnimal != "Ovino") || pesoAnimal <= 0)
            {
                ViewBag.Message = "Revise los datos ingresados.";
                return View();
            }
            else
            {
                IEnumerable<Animal> animales = s.GetAnimalesPorTipoYPeso(tipoAnimal, pesoAnimal);
                if(!animales.Any())
                {
                    ViewBag.Message = "No se encontraron animales con estos parametros.";
                    return View();
                }
                else
                {
                    ViewBag.TipoAnimal = tipoAnimal;
                    return View(animales);
                }
            }
        }
    }
}
