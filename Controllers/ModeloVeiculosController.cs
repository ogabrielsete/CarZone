using CarZone.Models;
using CarZone.Models.ViewModels;
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
            var listarMarcas = _marcasRepositorio.GetAll();
           
            var listarModelo = new List<ModeloVeiculoVM>();
            List<ModeloVeiculo> mostrar = _modeloVeiculosRepositorio.GetAll();
            foreach(var item in mostrar)
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
                    var dropdown = _marcasRepositorio.GetAll();
                    ViewBag.Marcas = new SelectList(dropdown, "Id", "Nome");

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
                    var dropdown = _marcasRepositorio.GetAll();
                    ViewBag.Marcas = new SelectList(dropdown, "Id", "Nome");

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
