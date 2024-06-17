using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PotreroController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        // GET: PotreroController
        public ActionResult Index()
        {
            IEnumerable<Potrero> potrerosOrdenados = s.GetPotrerosOrdenadosPorCapacidadYCantidad(); 
            return View(potrerosOrdenados);
        }

        // GET: PotreroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PotreroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PotreroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PotreroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PotreroController/Edit/5
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

        // GET: PotreroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PotreroController/Delete/5
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
