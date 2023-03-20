
using Tarefas.Business.Models;
using Tarefas.Business.Repository;

namespace Tarefas.Business.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<Tarefa> ObterTarefaPorId(Guid id);
    }
}
