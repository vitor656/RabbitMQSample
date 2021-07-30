using RabbitMQSample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Producer
{
    public class SpecificDirectExchangeProducer : DirectExchangeProducer, ISpecificDirectExchangeProducer
    {
        public SpecificDirectExchangeProducer(ConnectionProvider connectionProvider, ProducerConfigurations producerConfigurations) : base(connectionProvider, producerConfigurations)
        {
        }
    }
}
