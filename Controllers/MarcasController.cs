using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class MarcasController : Controller
    {
        private readonly IMarcasRepositorio _marcasRepositorio;
        public MarcasController(IMarcasRepositorio marcasRepositorio)
        {
            _marcasRepositorio = marcasRepositorio;
        }
        public IActionResult Index()
        {
            List<Marca> marcas = _marcasRepositorio.GetAll();
            return View(marcas);
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

        [HttpPost]
        public IActionResult Criar(Marca marcas)
        {
            _marcasRepositorio.Adicionar(marcas);
            return RedirectToAction("Index");
        }

    }
}
