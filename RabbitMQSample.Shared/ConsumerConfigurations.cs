using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Shared
{
    public record ConsumerConfigurations(string Exchange, string Queue, string RoutingKey);
}
