using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IPagamentosRepositorio
    {
        List<Pagamento> GetAll();
        Pagamento Adicionar(Pagamento pgto);
    }
}
