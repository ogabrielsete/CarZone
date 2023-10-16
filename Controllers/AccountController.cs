using CarZone.Models;
using CarZone.Models.ViewModels;
using FluentEmail.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Crypto.Generators;

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
            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user != null)
            {
                // Se os dados do usuário estão corretos, o acesso é confirmado
                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginVM.Password, false, false);
                if (result.Succeeded)
                {
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
                else
                {
                    TempData["MensagemErro"] = "Usuário ou senha incorreto, verifique e tente novamente.";
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

                    // Se o username tiver o final _admin, ele é admin se não ele é membro
                    if (user.UserName.Contains("_admin"))
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Member");
                    }

                    // Redireciona para a página de lggin
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
            try
            {
                if (!ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var userEmail = await _userManager.IsEmailConfirmedAsync(user);
                    var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                    if (userEmail == true)
                    {

                        string linkReset = Url.Action("ResetPassword", "Account",
                            new { userid = user.Id, token = resetToken },
                            protocol: HttpContext.Request.Scheme);

                        var subject = "Redefinição de senha";

                        var corpoEmail = $"Olá {user.UserName}! " +
                            $"Nós recebemos a solicitação de redefinição de senha da sua conta. " +
                            $"Para redefinir sua senha, <a href='{linkReset}'>clique aqui!</a>";

                        await _emailService.SendEmailAsync(user.Email, subject, corpoEmail);

                        TempData["MensagemSucesso"] = "O link para redefinir a senha foi enviado.";
                    }
                }
            }

            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Antes de solicitar a recuperação de senha, por favor, confirme o seu endereço de e-mail. (Detalhe:{e.Message})";
            }

            return View();

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

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            // Encontra o usuário
            var user = await _userManager.FindByIdAsync(model.UserId);
            // Redefinição de senha em 3 parametros
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                //Se tiver sucesso, mostra que a senha foi redefinida.
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


        // Página de Usuarios

        [Authorize]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            var userRoles = new Dictionary<string, string>();

            foreach (var user in users)
            {
                var roles = _userManager.GetRolesAsync(user).Result;
                var role = roles.FirstOrDefault();
                userRoles[user.Id] = role;
            }

            ViewBag.UserRoles = userRoles;
            return View(users);

        }

        [Authorize]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var model = new EditUserVM
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = roles.FirstOrDefault(), // Defina o papel atual aqui
                AvailableRoles = _roleManager.Roles
                    .Select(r => new SelectListItem { Value = r.Name, Text = r.Name })
                    .ToList()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserVM model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;

            // Verifique se o usuário tem a "Admin"
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isAdmin)
            {
                if (!user.UserName.Contains("_admin"))
                {
                    // Remove "Admin" e adiciona a "Member"
                    await _userManager.RemoveFromRoleAsync(user, "Admin");
                    await _userManager.AddToRoleAsync(user, "Member");
                }
            }
            else
            {
                // Se conter regra para ser admin, remove "Member" e adiciona a "Admin"
                if (user.UserName.Contains("_admin"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "Member");
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }

            return RedirectToAction("Index");

        }

    }
}

