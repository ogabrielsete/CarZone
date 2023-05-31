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
        public Pagamento ListarPorId(int id)
        {
            return _bancoContext.PagamentosDB.FirstOrDefault(x => x.Id == id);
        }

        public List<Pagamento> GetAll()
        {
            return _bancoContext.PagamentosDB.ToList();
        }

        public Pagamento Adicionar(Pagamento pgto)
        {
            _bancoContext.PagamentosDB.Add(pgto);
            _bancoContext.SaveChanges();
            return pgto;
        }

        public Pagamento Atualizar(Pagamento pgto)
        {
            Pagamento pagDB = ListarPorId(pgto.Id);
            if (pagDB == null) throw new Exception("Houve erro na atualização do Pagamento");

            pagDB.NomePagamento = pgto.NomePagamento;
            pagDB.Meses = pgto.Meses;
            pagDB.CategoriaVeiculo = pgto.CategoriaVeiculo;

            _bancoContext.PagamentosDB.Update(pagDB);
            _bancoContext.SaveChanges();

            return pagDB;
        }

        public bool Apagar(int id)
        {
            Pagamento pag = ListarPorId(id);
            if (pag == null) throw new Exception("Houve erro na exclusão da Marca");

            _bancoContext.PagamentosDB.Remove(pag);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
