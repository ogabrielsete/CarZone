using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IVeiculosRepositorio
    {
        List<Veiculo> GetAll();
        Veiculo ListarPorId(int id);
        Veiculo Adicionar(Veiculo veiculos);
        Veiculo Atualizar (Veiculo veiculos);
        bool Apagar(int id);
    }
}
