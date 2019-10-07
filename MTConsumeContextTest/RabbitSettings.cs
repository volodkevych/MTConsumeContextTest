using System;

namespace MTConsumeContextTest
{
    class RabbitSettings
    {
        public Uri RabbitUri => new Uri("rabbitmq://LocalCluster");
        public string RabbitPassword => "guest";
        public string RabbitUserName => "guest";
        public string[] RabbitNodes => new[] { "localhost" };
    }
}
