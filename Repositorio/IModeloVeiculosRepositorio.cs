using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IModeloVeiculosRepositorio
    {
        List<ModeloVeiculo> GetAll(int marcaId);
        ModeloVeiculo Adicionar(ModeloVeiculo modelo);


    }
}
