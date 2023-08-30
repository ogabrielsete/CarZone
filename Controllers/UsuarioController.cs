using CarZone.Models;
using CarZone.Repositorio;
using CarZone.Repositorio.Interfaces;
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
            List<Usuario> mostrarUsuarios = _usuarioRepositorio.GetAll();
            return View(mostrarUsuarios);
        }

        public IActionResult Criar()
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
            ModelState.Remove("Id");

            try
            {
                if (ModelState.IsValid)
                {
                    // Dados válidos, Adiciona ao repositório e redireciona para a Lista de Veiculos
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";

                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar o usuario, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }

            //_usuarioRepositorio.Adicionar(usuario);
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Dados válidos, Adiciona ao repositório e redireciona para a Lista de Veiculos
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso";

                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos alterar o usuario, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}
