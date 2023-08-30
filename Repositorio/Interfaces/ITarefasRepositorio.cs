using CarZone.Models;

namespace CarZone.Repositorio.Interfaces
{
    public interface ITarefasRepositorio
    {
        List<Tarefas> GetAll();
        Tarefas GetById(int id);
        Tarefas Adicionar(Tarefas tarefas);
        Tarefas Editar(Tarefas editar);
        public bool Apagar(int id);

    }
}
