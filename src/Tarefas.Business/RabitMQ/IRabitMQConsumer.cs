using Tarefas.Business.Models;

namespace Tarefas.Business.RabitMQ
{
    public interface IRabitMQConsumer
    {
        public Task<Tarefa> GetMessageAdicionarTarefa();
        public Task<Tarefa> GetMessageAtualizarTarefa();
    }
}
