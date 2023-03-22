using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Tarefas.Api.RabitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        private IConnection CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            return factory.CreateConnection();
        }
        public void AdicionaTarefaMessage<T>(T message)
        {
            var connection = CreateConnection();
            using
            var channel = connection.CreateModel();
            channel.QueueDeclare("QueueAdicionaTarefa", exclusive: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "QueueAdicionaTarefa", body: body);
        }

        public void AtualizaTarefaMessage<T>(T message)
        {
            var connection = CreateConnection();
            using
            var channel = connection.CreateModel();
            channel.QueueDeclare("QueueAtualizaTarefa", exclusive: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "QueueAtualizaTarefa", body: body);
        }
    }
}
