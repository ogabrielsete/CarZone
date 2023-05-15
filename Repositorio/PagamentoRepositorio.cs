using CarZone.Data;
using CarZone.Models;

namespace CarZone.Repositorio
{
    public class PagamentoRepositorio : IPagamentosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public PagamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Pagamento Adicionar(Pagamento pgto)
        {
            _bancoContext.PagamentosDB.Add(pgto);
            _bancoContext.SaveChanges();
            return pgto;
        }
    }
}
