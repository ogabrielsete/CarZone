using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);
        Usuario ListarPorId(int id);
        List<Usuario> GetAll();
        Usuario Atualizar(Usuario attCliente);
        Usuario Adicionar(Usuario cliente);
        bool Apagar(int id);
    }
}
