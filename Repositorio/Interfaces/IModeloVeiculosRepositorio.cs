using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IModeloVeiculosRepositorio
    {
        List<ModeloVeiculo> GetAll();
        IEnumerable<ModeloVeiculo> ObterModelosPorMarca(int marcaId);
        ModeloVeiculo ListarPorId(int id);
        ModeloVeiculo Adicionar(ModeloVeiculo modelo);
        ModeloVeiculo Atualizar(ModeloVeiculo model);
        bool Apagar(int id);




    }
}
