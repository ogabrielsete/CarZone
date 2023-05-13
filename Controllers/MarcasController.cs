using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class MarcasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMarca()
        {
            return View();
        }

        public IActionResult EditarMarca()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

    }
}
