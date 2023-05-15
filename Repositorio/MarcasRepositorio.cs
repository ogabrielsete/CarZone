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
        public Marcas Adicionar(Marcas marcas)
        {
            _bancoContext.MarcasDB.Add(marcas);
            _bancoContext.SaveChanges();
            return marcas;
        }
    }
}
