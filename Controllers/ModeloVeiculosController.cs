using CarZone.Models;
using CarZone.Models.ViewModels;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarZone.Controllers
{
    [Authorize]
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
            var listarMarcas = _marcasRepositorio.ObterTodos();           
            var listarModelo = new List<ModeloVeiculoVM>();

            List<ModeloVeiculo> modelos = _modeloVeiculosRepositorio.ObterTodos();

            foreach(var item in modelos)
            {
                var listar = new ModeloVeiculoVM();
                listar.Id = item.Id;
                listar.NomeModelo = item.NomeModelo;
                listar.Marca = listarMarcas.FirstOrDefault(x => x.Id == item.MarcaId).Nome;
                listarModelo.Add(listar);
            }            
            return View(listarModelo);
        }

        public IActionResult Criar()
        {
            var listaDropdown = _marcasRepositorio.ObterTodos   ();
            ViewBag.Marcas = new SelectList(listaDropdown, "Id", "Nome");
            return View();
        }

        public IActionResult EditarModelo(int id)
        {
            var listarMarcasDropDown = _marcasRepositorio.ObterTodos();
            ViewBag.Marcas = new SelectList(listarMarcasDropDown, "Id", "Nome");

            ModeloVeiculo editarModelo = _modeloVeiculosRepositorio.ObterPorId(id);
            return View(editarModelo);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ModeloVeiculo modelos = _modeloVeiculosRepositorio.ObterPorId(id);
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
            ModelState.Remove("Id");
            ModelState.Remove("Marca");

            try
            {
                if (ModelState.IsValid)
                {
                    _modeloVeiculosRepositorio.Adicionar(modelo);
                    TempData["MensagemSucesso"] = "Modelo cadastrado com sucesso";

                    return RedirectToAction("Index");
                }
                else
                {
                    var dropDownMarcas = _marcasRepositorio.ObterTodos();
                    ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome");

                    return View(modelo);
                }
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar o modelo do veiculo, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }       
        }

        public IActionResult Editar(ModeloVeiculo modelo)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Marca");

            try
            {
                if (ModelState.IsValid)
                {
                    _modeloVeiculosRepositorio.Atualizar(modelo);
                    TempData["MensagemSucesso"] = "Modelo alterado com sucesso";

                    return RedirectToAction("Index");
                }
                else
                {
                    var dropDownMarcas = _marcasRepositorio.ObterTodos();
                    ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome");

                    return View(modelo);
                }
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar o modelo do veiculo, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
