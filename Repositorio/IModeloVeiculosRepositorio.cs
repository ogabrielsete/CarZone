using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IModeloVeiculosRepositorio
    {
        List<ModeloVeiculo> GetAll();
        ModeloVeiculo ListarPorId(int id);
        ModeloVeiculo Adicionar(ModeloVeiculo modelo);
        ModeloVeiculo Atualizar(ModeloVeiculo model);
        bool Apagar(int id);

    }
}
