using RabbitMQ.Client.Events;
using RabbitMQSample.Shared;
using System;
using System.Text;

namespace RabbitMQSample.Consumer
{
    public class SpecificDirectExchangeConsumer : DirectExchangeConsumer, ISpecificDirectExchangeConsumer
    {
        public SpecificDirectExchangeConsumer(ConnectionProvider connectionProvider, ConsumerConfigurations consumerConfigurations) 
            : base(connectionProvider, consumerConfigurations)
        {
        }

        protected override void OnMessageReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Message Received: " + message);
        }
    }
}
