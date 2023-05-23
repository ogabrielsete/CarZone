using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IVeiculosRepositorio
    {
        List<Veiculo> GetAll();
        Veiculo Adicionar (Veiculo veiculos);
    }
}
