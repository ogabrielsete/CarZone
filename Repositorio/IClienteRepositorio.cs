using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IClienteRepositorio
    {
        List<Cliente> GetAll();
        Cliente Adicionar(Cliente cliente);
    }
}
