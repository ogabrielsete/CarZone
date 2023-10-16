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

        public LoginVM Editar(LoginVM loginVM)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginVM> ListarPorId(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new Exception("Usuário não encontrario"); // Ou algum tipo de tratamento para quando o usuário não for encontrado
            }

            var loginVM = new LoginVM
            {
                // Mapeie os dados do IdentityUser para o LoginVM aqui
                UserName = user.UserName,
                Email = user.Email,
                // ... outras propriedades do LoginVM
            };

            return loginVM;
        }
    }
}
