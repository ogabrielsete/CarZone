using CarZone.Data;
using CarZone.Models;

namespace CarZone.Repositorio
{
    public class ModeloVeiculosRepositorio : IModeloVeiculosRepositorio
    {   
        private readonly BancoContext _bancoContext;
        public ModeloVeiculosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ModeloVeiculo Adicionar(ModeloVeiculo modelo)
        {
            _bancoContext.ModeloVeiculosDB.Add(modelo);
            _bancoContext.SaveChanges();
            return modelo;  
        }

        public List<ModeloVeiculo> GetAll()
        {
            return _bancoContext.ModeloVeiculosDB.ToList();
        }
    }
}
