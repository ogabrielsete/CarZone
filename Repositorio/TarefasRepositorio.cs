using CarZone.Data;
using CarZone.Models;
using CarZone.Repositorio.Interfaces;

namespace CarZone.Repositorio
{
    public class TarefasRepositorio : ITarefasRepositorio
    {
        private readonly BancoContext _bancoContext;

        public TarefasRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Tarefas> GetAll()
        {
            return _bancoContext.TarefasDB.ToList();
        }

        public Tarefas GetById(int id)
        {
            return _bancoContext.TarefasDB.FirstOrDefault(x => x.Id == id);
        }

        public Tarefas Adicionar(Tarefas tarefas)
        {
            _bancoContext.TarefasDB.Add(tarefas);
            _bancoContext.SaveChanges();

            return tarefas;
        }

        public bool Apagar(int id)
        {
            Tarefas tarefas = GetById(id);
            if(tarefas == null) throw new Exception("Houve erro na exclusão de Tarefa");

            _bancoContext.TarefasDB.Remove(tarefas);
            _bancoContext.SaveChanges();
            return true;

        }

        public Tarefas Editar(Tarefas editar)
        {
            Tarefas tarefas = GetById(editar.Id);
            if (tarefas == null) throw new Exception("Houve erro na atualização da tarefa");

            tarefas.UserId = editar.UserId;
            tarefas.Concluido = editar.Concluido;
            tarefas.Descricao = editar.Descricao;

            _bancoContext.TarefasDB.Update(tarefas);
            _bancoContext.SaveChanges();
            return tarefas;
        }


    }
}
