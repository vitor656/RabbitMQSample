using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Shared
{
    public interface IProducer
    {
        void Publish<T>(T message);
    }
}
