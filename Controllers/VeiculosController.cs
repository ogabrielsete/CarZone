using CarZone.Models;
using CarZone.Models.ViewModels;
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
        {
            var listarMarcas = _marcasRep.GetAll();
            var listarModelo = _modeloVeiculosRepositorio.GetAll();

            var listarVeiculos = new List<VeiculosVM>();
            List<Veiculo> veiculos = _veiculosRepositorio.GetAll();
            foreach (var item in veiculos)
            {
                var listar = new VeiculosVM();
                listar.Id = item.Id;
                listar.Placa = item.Placa;
                listar.Ano = item.Ano;
                listar.Preco = item.Preco;
                listar.StatusVenda = item.StatusVenda;
                listar.Modelo = listarModelo.FirstOrDefault(x => x.Id == item.ModeloId).NomeModelo;
                listar.Marca = listarMarcas.FirstOrDefault(x => x.Id == item.MarcaId).Nome;
                listarVeiculos.Add(listar);
            }
            return View(listarVeiculos);
        }

        public IActionResult Criar()
        {
            var dropDownMarcas = _marcasRep.GetAll();
            ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome");

            var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
            ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");
            return View();
        }

        public IActionResult Editar(int id)
        {
            var dropDownMarcas = _marcasRep.GetAll();
            ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome");

            var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
            ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");

            Veiculo editarVeiculo = _veiculosRepositorio.ListarPorId(id);
            return View(editarVeiculo);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            Veiculo veiculo = _veiculosRepositorio.ListarPorId(id);
            return View(veiculo);
        }

        public IActionResult Apagar(int id)
        {
            _veiculosRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(Veiculo veiculos)
        {
            if (!ModelState.IsValid)
            {
                return View(veiculos);
            }
            _veiculosRepositorio.Adicionar(veiculos);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Atualizar(Veiculo veiculos)
        {
            _veiculosRepositorio.Atualizar(veiculos);
            return RedirectToAction("Index");
        }

    }
}
