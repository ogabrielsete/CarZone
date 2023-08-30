using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IVendasRepositorio
    {
        List<Venda> GetAll();
        Venda ListarPorId(int id);
        Venda Adicionar(Venda vendidos);
        Venda Atualizar(Venda vendidos);
        bool Apagar(int id);


        bool VendaRelacionada(int vendaId);
    }
}
