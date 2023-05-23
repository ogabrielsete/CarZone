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
        public Marca Adicionar(Marca marcas)
        {
            _bancoContext.MarcasDB.Add(marcas);
            _bancoContext.SaveChanges();
            return marcas;
        }

        public List<Marca> GetAll()
        {
            return _bancoContext.MarcasDB.ToList();
        }
    }
}
