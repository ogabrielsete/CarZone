using CarZone.Data;
using CarZone.Models;

namespace CarZone.Repositorio
{
    public class VeiculosRepositorio : IVeiculosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public VeiculosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Veiculo> GetAll()
        {
            return _bancoContext.VeiculosDB.ToList();
        }

        public Veiculo Adicionar(Veiculo veiculo)
        {
            _bancoContext.VeiculosDB.Add(veiculo);
            _bancoContext.SaveChanges();
            return veiculo;
        }

        
    }
}
