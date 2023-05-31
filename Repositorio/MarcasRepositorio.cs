using CarZone.Data;
using CarZone.Models;

namespace CarZone.Repositorio
{
    public class MarcasRepositorio : IMarcasRepositorio
    {
        private readonly BancoContext _bancoContext;
        public MarcasRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Marca> GetAll()
        {
            return _bancoContext.MarcasDB.ToList();
        }

        public Marca ListarPorId(int id)
        {
            return _bancoContext.MarcasDB.FirstOrDefault(x => x.Id == id);
        }


        public Marca Adicionar(Marca marcas)
        {
            _bancoContext.MarcasDB.Add(marcas);
            _bancoContext.SaveChanges();
            return marcas;
        }

        public Marca Atualizar(Marca marcas)
        {
            Marca marcaDB = ListarPorId(marcas.Id);
            if (marcaDB == null) throw new Exception("Houve erro na atualização da marca");

            marcaDB.Nome = marcas.Nome;

            _bancoContext.Update(marcaDB);
            _bancoContext.SaveChanges();

            return marcaDB;
        }

        public bool Apagar(int id)
        {
            Marca marcas = ListarPorId(id);
            if (marcas == null) throw new Exception("Houve erro na exclusão da Marca");

            _bancoContext.MarcasDB.Remove(marcas);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
