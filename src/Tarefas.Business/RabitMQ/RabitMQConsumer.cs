using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Tarefas.Business.Models;

namespace Tarefas.Business.RabitMQ
{
    public class RabitMQConsumer : IRabitMQConsumer
    {
        private IConnection CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            return factory.CreateConnection();
        }

        public async Task<Tarefa> GetMessageAdicionarTarefa()
        {
            var connection = CreateConnection();
            using
            var channel = connection.CreateModel();

            channel.QueueDeclare("QueueAdicionaTarefa", exclusive: false);
            var retorno = string.Empty;

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                retorno = message;
                await Task.Yield();
            };

            channel.BasicConsume(queue: "QueueAdicionaTarefa", autoAck: true, consumer: consumer);

            Task.Delay(1000).Wait();

            Tarefa? tarefa = DeserializarTarefa(retorno);

            return tarefa;
        }

        public async Task<Tarefa> GetMessageAtualizarTarefa()
        {
            var connection = CreateConnection();
            using
            var channel = connection.CreateModel();

            channel.QueueDeclare("QueueAtualizaTarefa", exclusive: false);
            var retorno = string.Empty;

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                retorno = message;
                await Task.Yield();
            };

            channel.BasicConsume(queue: "QueueAtualizaTarefa", autoAck: true, consumer: consumer);

            Task.Delay(1000).Wait();

            Tarefa? tarefa = DeserializarTarefa(retorno);

            return tarefa;
        }

        private static Tarefa? DeserializarTarefa(string retorno)
        {
            return System.Text.Json.JsonSerializer.Deserialize<Tarefa>(retorno);
        }
    }
}
