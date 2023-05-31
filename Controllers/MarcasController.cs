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

        public IActionResult EditarMarca(int id)
        {
            Marca editarMarca = _marcasRepositorio.ListarPorId(id);
            return View(editarMarca);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            Marca marcas = _marcasRepositorio.ListarPorId(id);
            return View(marcas);
        }

        public IActionResult Apagar(int id)
        {
            _marcasRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(Marca marcas)
        {
            _marcasRepositorio.Adicionar(marcas);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Editar (Marca marcas)
        {
            if (ModelState.IsValid)
            {
                _marcasRepositorio.Atualizar(marcas);
                return RedirectToAction("Index");
            }
            return View("Index", marcas);
        }



    }
}
