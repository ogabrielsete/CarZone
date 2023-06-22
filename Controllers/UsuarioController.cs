using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<Usuario> mostrarUsuarios =  _usuarioRepositorio.GetAll();
            return View(mostrarUsuarios);
        }

        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        public IActionResult AlterarUsuario(int id)
        {
            Usuario user = _usuarioRepositorio.ListarPorId(id);
            return View(user);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Usuario user = _usuarioRepositorio.ListarPorId(id);
            return View(user);
        }

        public IActionResult Apagar(int id)
        {
            _usuarioRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            _usuarioRepositorio.Adicionar(usuario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            _usuarioRepositorio.Atualizar(usuario);
            return RedirectToAction("Index");
        }

    }
}
