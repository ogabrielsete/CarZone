using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario ListarPorId(int id);
        List<Usuario> GetAll();
        Usuario Atualizar(Usuario attCliente);
        Usuario Adicionar(Usuario cliente);
        bool Apagar(int id);
    }
}
