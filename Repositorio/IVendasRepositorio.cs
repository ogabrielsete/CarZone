using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IVendasRepositorio
    {
        List<Venda> GetAll();
        Venda Adicionar(Venda vendidos);
    }
}
