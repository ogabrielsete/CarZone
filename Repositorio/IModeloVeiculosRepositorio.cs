using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IModeloVeiculosRepositorio
    {
        List<ModeloVeiculo> GetAll();
        ModeloVeiculo Adicionar(ModeloVeiculo modelo);


    }
}
