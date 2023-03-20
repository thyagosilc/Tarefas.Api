using Tarefas.Business.Models;

namespace Tarefas.Business.Interfaces
{
    public interface ITarefaService : IDisposable
    {
        Task<bool> Adicionar(Tarefa tarefa);
        Task<bool> Atualizar(Tarefa tarefa);
        Task<bool> Remover(Guid id);
        Task<Tarefa> ObterTarefaPorId(Guid id);
    }
}
