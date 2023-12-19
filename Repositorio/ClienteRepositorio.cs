using CarZone.Data;
using CarZone.Models;
using CarZone.Repositorio.Interfaces;

namespace CarZone.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Cliente ObterPorId(int id)
        {
            return _bancoContext.ClientesDB.FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> ObterTodos()
        {
            return _bancoContext.ClientesDB.ToList();
        }

        public Cliente Adicionar(Cliente cliente)
        {
            _bancoContext.ClientesDB.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }

        public Cliente Atualizar(Cliente attCliente)
        {
            Cliente clienteDB = ObterPorId(attCliente.Id);

            if (clienteDB == null) throw new Exception("Houve erro na atualização do Cliente");

            clienteDB.Nome = attCliente.Nome;
            clienteDB.CPF = attCliente.CPF;
            clienteDB.Telefone = attCliente.Telefone;
            clienteDB.Endereco = attCliente.Endereco;

            _bancoContext.ClientesDB.Update(clienteDB);
            _bancoContext.SaveChanges();

            return clienteDB;

        }

        public bool Apagar(int id)
        {
            Cliente clienteDB = ObterPorId(id);
            if (clienteDB == null) throw new Exception("Houve erro na exclusão do Cliente");

            _bancoContext.ClientesDB.Remove(clienteDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
