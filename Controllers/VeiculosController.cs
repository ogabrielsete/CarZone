using CarZone.Filters;
using CarZone.Models;
using CarZone.Models.ViewModels;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarZone.Controllers
{
    [UsuarioLogado]
    public class VeiculosController : Controller
    {
        private readonly IVeiculosRepositorio _veiculosRepositorio;
        private readonly IMarcasRepositorio _marcasRep;
        private readonly IModeloVeiculosRepositorio _modeloVeiculosRepositorio;
        private readonly IVendasRepositorio _vendasRepositorio;
        public VeiculosController(IVeiculosRepositorio veiculosRepositorio,
                                   IMarcasRepositorio marcasRep,
                                   IModeloVeiculosRepositorio modeloVeiculosRepositorio,
                                   IVendasRepositorio vendasRepositorio)
        {
            _veiculosRepositorio = veiculosRepositorio;
            _marcasRep = marcasRep;
            _modeloVeiculosRepositorio = modeloVeiculosRepositorio;
            _vendasRepositorio = vendasRepositorio;

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

        public IActionResult Atualizar(int id)
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

        public IActionResult ModelosPorMarca(int marcaId)
        {
            var modelos = _modeloVeiculosRepositorio.ModelosPorMarca(marcaId);
            return Json(modelos);
        }


        [HttpPost]
        public IActionResult Criar(Veiculo veiculo)
        {

            ModelState.Remove("Modelo");
            ModelState.Remove("Marca");
            ModelState.Remove("Id");

            try
            {
                if (ModelState.IsValid)
                {
                    // Dados válidos, Adiciona ao repositório e redireciona para a Lista de Veiculos
                    _veiculosRepositorio.Adicionar(veiculo);
                    TempData["MensagemSucesso"] = "Veiculo cadastrado com sucesso";

                    return RedirectToAction("Index");
                }
                else
                {
                    var dropDownMarcas = _marcasRep.GetAll();
                    ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome");

                    var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
                    ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");

                    return View(veiculo);
                }

            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu veiculo, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(Veiculo veiculo)
        {
            ModelState.Remove("Modelo");
            ModelState.Remove("Marca");
            ModelState.Remove("Id");

            try
            {
                if (ModelState.IsValid)
                {
                    // Dados válidos, Adiciona ao repositório e redireciona para a Lista de Veiculos
                    _veiculosRepositorio.Atualizar(veiculo);
                    TempData["MensagemSucesso"] = "Veiculo alterado com sucesso";

                    return RedirectToAction("Index");
                }
                else
                {
                    var dropDownMarcas = _marcasRep.GetAll();
                    ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome");

                    var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
                    ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");
                    return View(veiculo);
                }


            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos alterar seu veiculo, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }

}

