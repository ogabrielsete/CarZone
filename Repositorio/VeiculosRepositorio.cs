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
        public Veiculos Adicionar(Veiculos veiculo)
        {
            _bancoContext.VeiculosDB.Add(veiculo);
            _bancoContext.SaveChanges();
            return veiculo;
        }
    }
}
