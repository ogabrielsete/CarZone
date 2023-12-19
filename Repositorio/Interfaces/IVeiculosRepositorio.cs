using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IVeiculosRepositorio
    {
        List<Veiculo> ObterTodos();
        Veiculo ObterPorId(int id);
        Veiculo Adicionar(Veiculo veiculos);
        Veiculo Atualizar(Veiculo veiculos);
        bool Apagar(int id);


    }
}
