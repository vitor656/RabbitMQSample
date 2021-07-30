using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQSample.Shared;

namespace RabbitMQSample.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int num = random.Next(2);

            Console.WriteLine(num);

            if (num == 0)
                RunConsumerInit();
            else
                RunConsumerUpdate();

        }

        public static void RunConsumerInit()
        {
            var connectionProvider = new ConnectionProvider("amqp://guest:guest@localhost:5672");

            ISpecificDirectExchangeConsumer consumer = new SpecificDirectExchangeConsumer(
                connectionProvider, 
                new ConsumerConfigurations("demo-direct-exchange", "demo-direct-queue", "account.init")
            );
            
            consumer.Consume();
        }

        public static void RunConsumerUpdate()
        {
            var connectionProvider = new ConnectionProvider("amqp://guest:guest@localhost:5672");

            ISpecificDirectExchangeConsumer consumerUpdate = new SpecificDirectExchangeConsumer(
                connectionProvider, 
                new ConsumerConfigurations("demo-direct-exchange", "demo-direct-queue-update", "account.update")
            );

            consumerUpdate.Consume();
        }
    }
}
