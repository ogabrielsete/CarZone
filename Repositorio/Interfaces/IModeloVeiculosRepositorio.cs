using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IModeloVeiculosRepositorio
    {
        List<ModeloVeiculo> ObterTodos();
        IEnumerable<ModeloVeiculo> ObterModelosPorMarca(int marcaId);
        ModeloVeiculo ObterPorId(int id);
        ModeloVeiculo Adicionar(ModeloVeiculo modelo);
        ModeloVeiculo Atualizar(ModeloVeiculo model);
        bool Apagar(int id);




    }
}
