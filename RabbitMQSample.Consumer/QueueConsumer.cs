using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQSample.Shared;
using System;
using System.Text;

namespace RabbitMQSample.Consumer
{
    public class QueueConsumer
    {
        private readonly ConnectionProvider connectionProvider;

        public QueueConsumer(ConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public void Consume()
        {
            using var connection = connectionProvider.GetConnection();
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("demo-queue", true, consumer);
            Console.WriteLine("Consumer Started");
            Console.ReadLine();

        }
    }
}
