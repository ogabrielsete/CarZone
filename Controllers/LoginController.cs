using CarZone.Helper;
using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                                ISessao sessao,
                                IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;

        }
        public IActionResult Index()
        {
            // Quando usuário logado, irá redirecionar a Home
            if (_sessao.BuscarSessao() != null) return RedirectToAction("Index", "Home");
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
                            _sessao.CriarSessaoUsuario(usuario);
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

        [HttpPost]
        public IActionResult LinkRedefinirSenha(RedefinirSenha redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenha.Email, redefinirSenha.AcessoLogin);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string msg = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Nova senha - CarZone", msg);

                        if (emailEnviado) 
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Sua nova senha foi enviada para o e-mail cadastrado";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o e-mail. Por favor, tente novamente";
                        }
                        
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos encontrar seus dados, confira seus dados e tente novamente.";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha, tente novamente mais tarde. Detalhe do erro: {erro.Message}";

                return RedirectToAction("Index");

            }

        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }
    }
}
