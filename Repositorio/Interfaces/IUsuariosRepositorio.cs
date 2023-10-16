using CarZone.Models.ViewModels;

namespace CarZone.Repositorio.Interfaces
{
    public interface IUsuariosRepositorio
    {
        Task<LoginVM> ListarPorId (string id);
        LoginVM Editar(LoginVM loginVM);
    }
}
