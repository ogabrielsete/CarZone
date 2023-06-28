using CarZone.Data;
using CarZone.Models;
using CarZone.Models.ViewModels;

namespace CarZone.Repositorio
{
    public class VeiculosRepositorio : IVeiculosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public VeiculosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Veiculo> GetAll()
        {
            return _bancoContext.VeiculosDB.ToList();
        }

        public Veiculo ListarPorId(int id)
        {
            return _bancoContext.VeiculosDB.FirstOrDefault(x => x.Id == id);
        }

        public Veiculo Adicionar(Veiculo veiculo)
        {
            _bancoContext.VeiculosDB.Add(veiculo);
            _bancoContext.SaveChanges();
            return veiculo;
        }


        public Veiculo Atualizar(Veiculo veiculo)
        {
            Veiculo carDB = ListarPorId(veiculo.Id);
            if (carDB == null) throw new Exception("Houve erro na atualização do veiculo");

            carDB.MarcaId = veiculo.MarcaId;
            carDB.StatusVenda = veiculo.StatusVenda;
            carDB.Ano = veiculo.Ano;
            carDB.Preco = veiculo.Preco;
            carDB.ModeloId = veiculo.ModeloId;
            carDB.Placa = veiculo.Placa;

            _bancoContext.VeiculosDB.Update(carDB);
            _bancoContext.SaveChanges();

            return carDB;
        }

        public bool Apagar(int id)
        {
            Veiculo carro = ListarPorId(id);
            if (carro == null) throw new Exception("Houve erro na exclusão da Marca");

            _bancoContext.VeiculosDB.Remove(carro);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
