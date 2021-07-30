using RabbitMQSample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Shared
{
    public abstract class BaseConsumer : IConsumer
    {
        protected readonly ConnectionProvider connectionProvider;
        protected readonly ConsumerConfigurations consumerConfigurations;

        public BaseConsumer(ConnectionProvider connectionProvider, ConsumerConfigurations consumerConfigurations)
        {
            this.connectionProvider = connectionProvider;
            this.consumerConfigurations = consumerConfigurations;
        }
        public abstract void Consume();
    }
}
