using CarZone.Models;
using CarZone.Models.ViewModels;
using FluentEmail.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<IdentityUser> userManager,
                                    SignInManager<IdentityUser> signInManager,
                                    IEmailService email)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = email;
        }


        public IActionResult Login(string returnUrl)
        {
            return View(new LoginVM()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            //if (ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginVM.Password, false, false);
                if (result.Succeeded)
                {

                    // Se os dados do usuário estão corretos, o acesso é confirmado
                    // Encontra o usuário pelo Username
                    var usuario = await _userManager.FindByNameAsync(loginVM.UserName);

                    // Se confirmou o e-mail, acesso é liberado, se não, acesso é rejeitado e reportado uma mensagem 
                    if (user.EmailConfirmed)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Caso o e-mail não seja confirmado, não permite acesso e reporta o erro
                        TempData["MensagemErro"] = $"Por favor, confirme sua conta antes de fazer o login e tente novamente.";
                        await _signInManager.SignOutAsync();

                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Falha ao realizar login!");
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginVM registroVM)
        {
            if (!ModelState.IsValid)
            {

                var user = new IdentityUser { UserName = registroVM.UserName, Email = registroVM.Email };
                var result = await _userManager.CreateAsync(user, registroVM.Password);
                if (result.Succeeded)
                {
                    // Gera um token para a confirmação
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    // Envia o e-mail com o link de confirmação
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                                                     new { userId = user.Id, token = token },
                                                     Request.Scheme);

                    var subject = "Confirmação de Cadastro";
                    var body = $"Obrigado por se cadastrar {user.UserName}. Por favor, confirme o seu cadastro clicando <a href='{confirmationLink}'>aqui</a>";

                    await _emailService.SendEmailAsync(user.Email, subject, body);

                    // Redirecione para a página de lggin
                    return RedirectToAction("Login");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
                }
            }
            return View();
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

        
        public IActionResult ForgotPassword()
        {
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(LoginVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            string linkReset = Url.Action("ResetPassword", "Account", 
                new {userid = user.Id, token = resetToken}, 
                protocol: HttpContext.Request.Scheme);

            var subject = "Redefinição de senha";

            var corpoEmail = $"Olá {user.UserName}! " +
                $"Nós recebemos a solicitação de redefinição de senha da sua conta. " +
                $"Para redefinir sua senha, <a href='{linkReset}'>clique aqui!</a>";

            await _emailService.SendEmailAsync(user.Email, subject, corpoEmail);

            ViewBag.Msg = "O link para redefinir a senha foi enviado.";

            return View();

        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            //Here i create the object of ResetPasswordViewModel
            var obj = new ResetPasswordVM()
            {
                UserId = userId,
                Token = token
            };


            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            // Encontra o usuário
            var user = await _userManager.FindByIdAsync(model.UserId);
            // Redefinição de senha em 3 parametros
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                //if succeed you can redirect to login page
                ViewBag.Msg = "Senha redefinida com sucesso!";
            }
            else
            {
                ViewBag.Msg = "Redefinição de senha falhou!";
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
    }
}
