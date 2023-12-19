using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        Cliente ObterPorId(int id);
        List<Cliente> ObterTodos();
        Cliente Atualizar(Cliente attCliente);
        Cliente Adicionar(Cliente cliente);
        bool Apagar(int id);
    }
}
