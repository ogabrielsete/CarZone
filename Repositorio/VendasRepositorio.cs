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

        public List<Venda> GetAll()
        {
            return _bancoContext.VendasDB.ToList();
        }

        public Venda Adicionar(Venda vendidos)
        {
            _bancoContext.VendasDB.Add(vendidos);
            _bancoContext.SaveChanges();
            return vendidos;
        }

        
    }
}
