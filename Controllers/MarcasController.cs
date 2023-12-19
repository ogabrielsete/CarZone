
using CarZone.Models;
using CarZone.Repositorio;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CarZone.Controllers
{

    [Authorize(Roles ="Admin")]
    public class MarcasController : Controller
    {
        private readonly IMarcasRepositorio _marcasRepositorio;
        public MarcasController(IMarcasRepositorio marcasRepositorio)
        {
            _marcasRepositorio = marcasRepositorio;
        }

        public IActionResult Index()
        {
            List<Marca> listarMarcas = _marcasRepositorio.ObterTodos();
            return View(listarMarcas);
        }

        [Authorize("Admin")]
        public IActionResult Criar()
        {
            return View();
        }

        [Authorize("Admin")]
        public IActionResult EditarMarca(int id)
        {
            Marca editarMarca = _marcasRepositorio.ObterPorId(id);
            return View(editarMarca);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Marca marcas = _marcasRepositorio.ObterPorId(id);
            return View(marcas);
        }


        public IActionResult Apagar(int id)
        {
            _marcasRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(Marca marca)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Modelos");

            try
            {
                if (ModelState.IsValid)
                {
                    _marcasRepositorio.Adicionar(marca);
                    TempData["MensagemSucesso"] = "Marca cadastrada com sucesso";

                    return RedirectToAction("Index");
                }
                return View(marca);
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar a marca do veiculo, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [Authorize("Admin")]
        public IActionResult Editar (Marca marca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _marcasRepositorio.Atualizar(marca);
                    TempData["MensagemSucesso"] = "Marca alterada com sucesso";

                    return RedirectToAction("Index");
                }
                return View(marca);
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos alterar a marca do veiculo, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
