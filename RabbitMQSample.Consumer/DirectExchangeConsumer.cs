using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQSample.Shared;
using System;

namespace RabbitMQSample.Consumer
{
    public abstract class DirectExchangeConsumer : BaseConsumer
    {

        public DirectExchangeConsumer(ConnectionProvider connectionProvider, ConsumerConfigurations consumerConfigurations) 
            : base(connectionProvider, consumerConfigurations)
        {
        }

        public override void Consume()
        {
            var connection = connectionProvider.GetConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(consumerConfigurations.Exchange, ExchangeType.Direct);
            channel.QueueDeclare(consumerConfigurations.Queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.QueueBind(consumerConfigurations.Queue, consumerConfigurations.Exchange, consumerConfigurations.RoutingKey);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += OnMessageReceived;

            channel.BasicConsume(consumerConfigurations.Queue, true, consumer);

            Console.WriteLine("Consumer Started");
            Console.ReadKey();
        }

        protected abstract void OnMessageReceived(object sender, BasicDeliverEventArgs e);
    }
}
