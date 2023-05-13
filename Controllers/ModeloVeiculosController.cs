using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class ModeloVeiculosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdicionarModelo()
        {
            return View();
        }

        public IActionResult EditarModelo()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
    }
}
