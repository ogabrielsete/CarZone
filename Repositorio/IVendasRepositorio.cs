using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IVendasRepositorio
    {
        List<Venda> GetAll();
        Venda ListarPorId (int id);
        Venda Adicionar(Venda vendidos);
        Venda Atualizar(Venda vendidos);
    }
}
