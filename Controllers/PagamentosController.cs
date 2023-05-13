using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class PagamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CriarPagamento()
        {
            return View();
        }

        public IActionResult EditarPagamento()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

       

    }
}
