using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IMarcasRepositorio
    {
        Marca Adicionar(Marca marcas);
        List<Marca> GetAll();
    }
}
