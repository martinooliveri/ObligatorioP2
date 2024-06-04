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
            if(a.Count > 0) 
            {
                return View(a);
            }
            return View();
        }

        // GET: Animal
        public ActionResult Index()
        {
            return View();
        }



        // GET: Animal/AltaBovino
        [HttpGet]
        public ActionResult AltaBovino()
        {
            return View();
        }

        // POST: Animal/AltaBovino
        [HttpPost]
        public ActionResult AltaBovino(Bovino b)
        {
            try
            {
                s.AltaAnimal(b);
                ViewBag.Message = "Alta de bovino exitosa";
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Animal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
