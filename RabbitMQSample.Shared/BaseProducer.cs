using RabbitMQSample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Shared
{
    public abstract class BaseProducer : IProducer
    {
        protected readonly ConnectionProvider connectionProvider;
        protected readonly ProducerConfigurations producerConfigurations;

        public BaseProducer(ConnectionProvider connectionProvider, ProducerConfigurations producerConfigurations)
        {
            this.connectionProvider = connectionProvider;
            this.producerConfigurations = producerConfigurations;
        }

        public abstract void Publish<T>(T message);
    }
}
