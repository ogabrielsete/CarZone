using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculosRepositorio _veiculosRepositorio;
        public VeiculosController(IVeiculosRepositorio veiculosRepositorio)
        {
            _veiculosRepositorio = veiculosRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar (Veiculo veiculos)
        {
            _veiculosRepositorio.Adicionar(veiculos);
            return RedirectToAction("Index");
        }
    }
}
