using CarZone.Data;
using CarZone.Models;
using CarZone.Models.ViewModels;
using CarZone.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarZone.Repositorio
{
    public class ModeloVeiculosRepositorio : IModeloVeiculosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ModeloVeiculosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ModeloVeiculo> ObterTodos()
        {
            return _bancoContext.ModeloVeiculosDB.ToList();
        }

        public ModeloVeiculo ObterPorId(int id)
        {
            return _bancoContext.ModeloVeiculosDB.FirstOrDefault(x => x.Id == id);
        }

        public ModeloVeiculo Adicionar(ModeloVeiculo modelo)
        {
            _bancoContext.ModeloVeiculosDB.Add(modelo);
            _bancoContext.SaveChanges();
            return modelo;
        }

        public ModeloVeiculo Atualizar(ModeloVeiculo model)
        {
            ModeloVeiculo modeloDB = ObterPorId(model.Id);
            if (modeloDB == null) throw new Exception("Houve erro na atualização do modelo do veiculo");

            modeloDB.NomeModelo = model.NomeModelo;
            
            _bancoContext.ModeloVeiculosDB.Update(modeloDB);
            _bancoContext.SaveChanges();

            return modeloDB;
        }

        public bool Apagar(int id)
        {
            ModeloVeiculo modelo = ObterPorId(id);
            if (modelo == null) throw new Exception("Houve erro na exclusão do modelo de veículo");

            _bancoContext.ModeloVeiculosDB.Remove(modelo);
            _bancoContext.SaveChanges();
            return true;
        }


        public IEnumerable<ModeloVeiculo> ObterModelosPorMarca(int marcaId)
        {
            return _bancoContext.ModeloVeiculosDB.Where(x => x.MarcaId == marcaId).ToList();
        }

    }
}
