using CarZone.Data;
using CarZone.Models.ViewModels;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CarZone.Repositorio
{
    public class UsuarioRepositorio : IUsuariosRepositorio
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioRepositorio(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<LoginVM> ObterPorId(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new Exception("Usuário não encontrario"); // Ou algum tipo de tratamento para quando o usuário não for encontrado
            }

            var loginVM = new LoginVM
            {
                UserName = user.UserName,
                Email = user.Email,
            };

            return loginVM;
        }
    }
}
