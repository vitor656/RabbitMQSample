using RabbitMQ.Client;
using RabbitMQSample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQSample.Shared
{
    public class QueueProducer
    {
        private readonly ConnectionProvider connectionProvider;

        public QueueProducer(ConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public void Publish()
        {
            var connection = connectionProvider.GetConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var count = 0;

            while (true)
            {
                var message = new {
                    Name = "Producer",
                    Message = $"Hello! Count: {count}"
                };

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                channel.BasicPublish("", "demo-queue", null, body);

                count++;

                Thread.Sleep(1000);
            }

        }
    }
}
