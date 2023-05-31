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
            IMarcasRepositorio marcasRepositorio)
        {
            _modeloVeiculosRepositorio = modeloVeiculosRepositorio;
            _marcasRepositorio = marcasRepositorio;
        }
        public IActionResult Index()
        {
            List<ModeloVeiculo> mostrarModelos = _modeloVeiculosRepositorio.GetAll();
            return View(mostrarModelos);
        }
        public IActionResult AdicionarModelo()
        {
            var dropdown = _marcasRepositorio.GetAll();
            ViewBag.Marcas = new SelectList(dropdown, "Id", "Nome");
            return View();
        }

        public IActionResult EditarModelo(int id)
        {
            var dropdown = _marcasRepositorio.GetAll();
            ViewBag.Marcas = new SelectList(dropdown, "Id", "Nome");
            ModeloVeiculo editarmodelo = _modeloVeiculosRepositorio.ListarPorId(id);
            return View(editarmodelo);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ModeloVeiculo modelos = _modeloVeiculosRepositorio.ListarPorId(id);
            return View(modelos);
        }

        public IActionResult Apagar(int id)
        {
            _modeloVeiculosRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(ModeloVeiculo modelo)
        {
            _modeloVeiculosRepositorio.Adicionar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(ModeloVeiculo modelo)
        {
            _modeloVeiculosRepositorio.Atualizar(modelo);
            return RedirectToAction("Index");
        }

    }
}
