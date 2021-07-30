using RabbitMQ.Client;
using System;

namespace RabbitMQSample.Shared
{
    public class ConnectionProvider : IDisposable
    {

        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;

        public ConnectionProvider(string Uri)
        {
            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(Uri)
            };
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public IConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = _connectionFactory.CreateConnection();
            }

            return _connection;
        }
    }
}
