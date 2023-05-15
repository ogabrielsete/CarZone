using CarZone.Data;
using CarZone.Models;

namespace CarZone.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Cliente Adicionar(Cliente cliente)
        {
            _bancoContext.ClientesDB.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }
    }
}
