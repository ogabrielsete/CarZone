using CarZone.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CarZone.Repositorio.Interfaces
{
    public interface IUsuariosRepositorio
    {
        Task<LoginVM> ObterPorId (string id);
    }
}
