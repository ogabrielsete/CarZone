using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarZone.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculosRepositorio _veiculosRepositorio;
        private readonly IMarcasRepositorio _marcasRep;
        private readonly IModeloVeiculosRepositorio _modeloVeiculosRepositorio;
        public VeiculosController(IVeiculosRepositorio veiculosRepositorio,
                                   IMarcasRepositorio marcasRep,
                                   IModeloVeiculosRepositorio modeloVeiculosRepositorio)
        {
            _veiculosRepositorio = veiculosRepositorio;
            _marcasRep = marcasRep; 
            _modeloVeiculosRepositorio = modeloVeiculosRepositorio;

        }
        public IActionResult Index()
        {// usar view model para mostrar marcas e modelos
            List<Veiculo> mostrarVeiculos = _veiculosRepositorio.GetAll();
            return View(mostrarVeiculos);
        }

        public IActionResult Criar()
        {
            var dropDownMarcas = _marcasRep.GetAll();
            ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome");

            var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
            ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");
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
