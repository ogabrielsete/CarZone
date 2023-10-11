using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuariosController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public IActionResult Editar()
        {
            return View();
        }


    }
}
