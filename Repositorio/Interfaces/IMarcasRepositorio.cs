using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface IMarcasRepositorio
    {
        List<Marca> ObterTodos();
        Marca ObterPorId(int id);
        Marca Adicionar(Marca marcas);
        Marca Atualizar(Marca marcas);
        bool Apagar(int id);

    }
}
