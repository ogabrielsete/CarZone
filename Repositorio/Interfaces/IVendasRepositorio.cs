using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IVendasRepositorio
    {
        List<Venda> ObterTodos();
        Venda ObterPorId(int id);
        Venda Adicionar(Venda vendidos);
        Venda Atualizar(Venda vendidos);
        bool Apagar(int id);


        bool VendaRelacionada(int vendaId);
    }
}
