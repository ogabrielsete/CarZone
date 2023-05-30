using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IMarcasRepositorio
    {
        List<Marca> GetAll();
        Marca ListarPorId(int id);
        Marca Adicionar(Marca marcas);
        Marca Atualizar(Marca marcas);

    }
}
