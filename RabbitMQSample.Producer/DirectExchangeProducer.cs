using RabbitMQ.Client;
using RabbitMQSample.Shared;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace RabbitMQSample.Producer
{
    public class DirectExchangeProducer : BaseProducer
    {
        public DirectExchangeProducer(ConnectionProvider connectionProvider, ProducerConfigurations producerConfigurations) 
            : base(connectionProvider, producerConfigurations)
        {
        }

        public override void Publish<T>(T message)
        {
            using var connection = connectionProvider.GetConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(producerConfigurations.Exchange, ExchangeType.Direct);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(message));

            channel.BasicPublish(producerConfigurations.Exchange, producerConfigurations.RoutingKey, null, body);

        }
    }
}
