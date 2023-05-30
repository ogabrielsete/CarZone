using CarZone.Data;
using CarZone.Models;

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


        public Veiculo Atualizar(Veiculo veiculos)
        {
            Veiculo carDB = ListarPorId(veiculos.Id);
            if (carDB == null) throw new Exception("Houve erro na atualização do veiculo");

            carDB.StatusVenda = veiculos.StatusVenda;
            carDB.Ano = veiculos.Ano;
            carDB.Preco = veiculos.Preco;
            carDB.ModeloId = veiculos.ModeloId;

            _bancoContext.VeiculosDB.Update(carDB);
            _bancoContext.SaveChanges();

            return carDB;
        }
    }
}
