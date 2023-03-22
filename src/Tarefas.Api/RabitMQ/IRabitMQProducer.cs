namespace Tarefas.Api.RabitMQ
{
    public interface IRabitMQProducer
    {
        public void AdicionaTarefaMessage<T>(T message);

        public void AtualizaTarefaMessage<T>(T message);
    }
}
