using Tarefas.Business.Models;

namespace Tarefas.Business.Interfaces
{
    public interface ITarefaService : IDisposable
    {
        Task<bool> Adicionar();
        Task<bool> Atualizar();
        Task<bool> Remover(Guid id);
        Task<Tarefa> ObterTarefaPorId(Guid id);
    }
}
