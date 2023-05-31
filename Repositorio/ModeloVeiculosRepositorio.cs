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

        public List<ModeloVeiculo> GetAll()
        {
            return _bancoContext.ModeloVeiculosDB.ToList();
        }

        public ModeloVeiculo ListarPorId(int id)
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
            ModeloVeiculo modeloDB = ListarPorId(model.Id);
            if (modeloDB == null) throw new Exception("Houve erro na atualização do modelo do veiculo");

            modeloDB.NomeModelo = model.NomeModelo;
            //modeloDB.MarcaId = model.MarcaId;
            //modeloDB.Marca = model.Marca;

            _bancoContext.ModeloVeiculosDB.Update(modeloDB);
            _bancoContext.SaveChanges();

            return modeloDB;
        }

        public bool Apagar(int id)
        {
            ModeloVeiculo modelo = ListarPorId(id);
            if (modelo == null) throw new Exception("Houve erro na exclusão do modelo de veículo");

            _bancoContext.ModeloVeiculosDB.Remove(modelo);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
