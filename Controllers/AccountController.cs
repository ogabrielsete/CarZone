using CarZone.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarZone.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<IdentityUser> userManager,
                                    SignInManager<IdentityUser> signInManager,
                                    IEmailService email,
                                    RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = email;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            return View(new LoginVM()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpGet]
        public async Task<ActionResult> Register(string returnUrl = null)
        {
            return View(new LoginVM()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return View("EmailConfirmed");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            // Aqui eu crio um objeto da ResetPasswordVM
            var obj = new ResetPasswordVM()
            {
                UserId = userId,
                Token = token
            };


            return View(obj);
        }


        // Métodos Post


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            // Se o usuário não preencher os campos, retorna uma mensagem de erro
            if (string.IsNullOrEmpty(loginVM.UserName) || string.IsNullOrEmpty(loginVM.Password))
            {
                TempData["MensagemErro"] = "Por favor, preencha os campos e tente novamente.";
                return RedirectToAction("Index", "Home");
            }

            IdentityUser procuraUsuario = await _userManager.FindByNameAsync(loginVM.UserName);

            if (procuraUsuario != null)
            {
                var confirmaUsuarioESenha = await _signInManager.PasswordSignInAsync(procuraUsuario.UserName, loginVM.Password, false, false);
                if (confirmaUsuarioESenha.Succeeded)
                {
                    if (procuraUsuario.EmailConfirmed)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Por favor, confirme sua conta antes de fazer o login e tente novamente.";
                        await _signInManager.SignOutAsync();
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MensagemErro"] = "Usuário ou senha incorreto, verifique e tente novamente.";
                }
            }
            ModelState.AddModelError("", "Falha ao realizar login!");
            return View(loginVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginVM registroVM)
        {

            if (ModelState.IsValid)
            {
                IdentityUser novoUsuario = new IdentityUser { UserName = registroVM.UserName, Email = registroVM.Email };
                IdentityResult resultadoNovoUsuario = await _userManager.CreateAsync(novoUsuario, registroVM.Password);

                if (resultadoNovoUsuario.Succeeded)
                {
                    string geraTokenParaConfirmacao = await _userManager.GenerateEmailConfirmationTokenAsync(novoUsuario);
                    string linkDeConfirmacao = GerarLinkDeEmailDeConfirmacao(novoUsuario.Id, geraTokenParaConfirmacao);
                    string tituloEmail = "Confirmação de Cadastro";
                    string corpoEmail = $"Obrigado por se cadastrar {novoUsuario.UserName}. Por favor, confirme o seu cadastro clicando <a href='{linkDeConfirmacao}'>aqui</a>";

                    await _emailService.SendEmailAsync(novoUsuario.Email, tituloEmail, corpoEmail);

                    // Se o username tiver o final _admin, ele é admin se não ele é membro
                    if (novoUsuario.UserName.Contains("_admin"))
                    {
                        await _userManager.AddToRoleAsync(novoUsuario, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(novoUsuario, "Member");
                    }

                    TempData["MensagemSucesso"] = $"Obrigado por se cadastrar {novoUsuario.UserName}. " +
                        $"Por favor, confirme o seu cadastro clicando no link que enviamos para o seu e-mail";

                    return View(registroVM);
                }
                else
                {
                    TempData["MensagemErro"] = $"Ocorreu um erro ao realizar o cadastro. " +
                                               $"Por favor, tente novamente. (Detalhe: {resultadoNovoUsuario.Errors})";
                }
            }

            return View(registroVM);
        }

        private string GerarLinkDeEmailDeConfirmacao(string userId, string token)
        {
            return Url.Action("ConfirmEmail", "Account",
                new { userId, token },
                Request.Scheme);
        }

        public IActionResult ForgotPassword()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    IdentityUser procurarUsuarioPorEmail = await _userManager.FindByEmailAsync(model.Email);
                    bool emailConfirmado = await _userManager.IsEmailConfirmedAsync(procurarUsuarioPorEmail);
                    string tokenRedefinicaoSenha = await _userManager.GeneratePasswordResetTokenAsync(procurarUsuarioPorEmail);

                    if (emailConfirmado == true)
                    {

                        string linkReset = Url.Action("ResetPassword", "Account",
                        new { userid = procurarUsuarioPorEmail.Id, token = tokenRedefinicaoSenha },
                        protocol: HttpContext.Request.Scheme);

                        var subject = "Redefinição de senha";

                        var corpoEmail = $"Olá {procurarUsuarioPorEmail.UserName}! " +
                        $"Nós recebemos a solicitação de redefinição de senha da sua conta. " +
                        $"Para redefinir sua senha, <a href='{linkReset}'>clique aqui!</a>";

                        await _emailService.SendEmailAsync(procurarUsuarioPorEmail.Email, subject, corpoEmail);

                        TempData["MensagemSucesso"] = "O link para redefinir a senha foi enviado.";
                    }
                }
            }

            catch (Exception)
            {
                TempData["MensagemErro"] = $"Antes de solicitar a recuperação de senha, por favor, confirme o seu endereço de e-mail";
            }

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            IdentityUser buscaUsuarioPorId = await _userManager.FindByIdAsync(model.UserId);
            IdentityResult redefinirSenha = await _userManager.ResetPasswordAsync(buscaUsuarioPorId, model.Token, model.Password);

            if (redefinirSenha.Succeeded)
            {
                TempData["MensagemSucesso"] = "Senha redefinida com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro ao redefinir a senha. Por favor, tente novamente.";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        // Página de Usuarios

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<IdentityUser> listaUsuarios = _userManager.Users.ToList();
            var funcaoUsuario = new Dictionary<string, string>();

            foreach (var usuario in listaUsuarios)
            {
                var roles = _userManager.GetRolesAsync(usuario).Result;
                var funcao = roles.FirstOrDefault();
                funcaoUsuario[usuario.Id] = funcao;
            }

            ViewBag.UserRoles = funcaoUsuario;
            return View(listaUsuarios);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUser(string id)
        {
            var usuarioEncontrado = await _userManager.FindByIdAsync(id);

            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(usuarioEncontrado);

            var model = new EditUserVM
            {
                UserId = usuarioEncontrado.Id,
                UserName = usuarioEncontrado.UserName,
                Email = usuarioEncontrado.Email,
                Role = roles.FirstOrDefault(), 
                AvailableRoles = _roleManager.Roles
                    .Select(r => new SelectListItem { Value = r.Name, Text = r.Name })
                    .ToList()
            };

            return View(model);
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserVM model)
        {
            IdentityUser usuarioEncontrado = await _userManager.FindByIdAsync(model.UserId);

            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            usuarioEncontrado.UserName = model.UserName;
            usuarioEncontrado.Email = model.Email;

            await _userManager.UpdateAsync(usuarioEncontrado);

            bool isAdmin = await _userManager.IsInRoleAsync(usuarioEncontrado, "Admin");

            if (isAdmin)
            {
                if (!usuarioEncontrado.UserName.Contains("_admin"))
                {
                    await _userManager.RemoveFromRoleAsync(usuarioEncontrado, "Admin");
                    await _userManager.AddToRoleAsync(usuarioEncontrado, "Member");
                }
            }
            else
            {
                if (usuarioEncontrado.UserName.Contains("_admin"))
                {
                    await _userManager.RemoveFromRoleAsync(usuarioEncontrado, "Member");
                    await _userManager.AddToRoleAsync(usuarioEncontrado, "Admin");
                }
            }

            return RedirectToAction("Index");

        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}

