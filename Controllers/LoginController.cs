using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepositorio.BuscarPorLogin(login.AcessoLogin);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(login.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    }
                    TempData["MensagemErro"] = $"Usuario e/ou senha inválidos. Por favor, tente novamente.";
                }
                return View("Index");
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos realizar seu login, tente novamente. Detalhe do erro: { erro.Message}";

                return RedirectToAction("Index");

            }
        }
    }
}
