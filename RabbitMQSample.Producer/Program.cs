using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQSample.Producer;
using RabbitMQSample.Shared;

namespace RabbitMQSample.Shared
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new ConnectionProvider("amqp://guest:guest@localhost:5672");
            //var producer = new QueueProducer(provider);
            //var producer = new DirectExchangeProducer(provider);
            ISpecificDirectExchangeProducer producer = new SpecificDirectExchangeProducer(provider, new ProducerConfigurations("demo-direct-exchange", "account.init"));
            ISpecificDirectExchangeProducer producerUpdate = new SpecificDirectExchangeProducer(provider, new ProducerConfigurations("demo-direct-exchange", "account.update"));

            int count = 0;
            while(true)
            {
                var message = new Message("Test Message init", $"Teste Content {count}");
                var messageUpdate = new Message("Test Message update", $"Teste Content {count}");

                Console.WriteLine("Send init");
                producer.Publish<Message>(message);
                
                Console.WriteLine("Send update");
                producerUpdate.Publish<Message>(messageUpdate);
                Thread.Sleep(1000);

                count++;
            }
        }
    }
}
