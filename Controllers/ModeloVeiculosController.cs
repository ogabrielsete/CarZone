using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarZone.Controllers
{
    public class ModeloVeiculosController : Controller
    {
        private readonly IModeloVeiculosRepositorio _modeloVeiculosRepositorio;
        private readonly IMarcasRepositorio _marcasRepositorio;
        public ModeloVeiculosController(IModeloVeiculosRepositorio modeloVeiculosRepositorio,
            IMarcasRepositorio marcasRepositorio )
        {
            _modeloVeiculosRepositorio = modeloVeiculosRepositorio;
            _marcasRepositorio = marcasRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdicionarModelo()
        {
            var dropdown = _marcasRepositorio.GetAll();
            ViewBag.Marcas = new SelectList(dropdown, "Id", "Nome");
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

        [HttpPost]
        public IActionResult Criar (ModeloVeiculo modelo)
        {

            _modeloVeiculosRepositorio.Adicionar(modelo);
            return RedirectToAction("Index");
        }
        
    }
}
