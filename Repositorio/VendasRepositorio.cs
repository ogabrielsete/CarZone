using CarZone.Data;
using CarZone.Models;

namespace CarZone.Repositorio
{
    public class VendasRepositorio : IVendasRepositorio
    {
        private readonly BancoContext _bancoContext;
        public VendasRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Vendas Adicionar(Vendas vendidos)
        {
            _bancoContext.VendasDB.Add(vendidos);
            _bancoContext.SaveChanges();
            return vendidos;
        }
    }
}
