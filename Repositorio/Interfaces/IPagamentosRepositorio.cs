using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IPagamentosRepositorio
    {
        List<Pagamento> ObterTodos();
        Pagamento ObterPorId(int id);
        Pagamento Adicionar(Pagamento pgto);
        Pagamento Atualizar(Pagamento pgto);
        bool Apagar(int id);
    }
}
