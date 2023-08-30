using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        Cliente ListarPorId(int id);
        List<Cliente> GetAll();
        Cliente Atualizar(Cliente attCliente);
        Cliente Adicionar(Cliente cliente);
        bool Apagar(int id);
    }
}
