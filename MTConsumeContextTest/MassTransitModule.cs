using Autofac;
using MassTransit;
using MTConsumeContextTest.Consumer;
using System;

namespace MTConsumeContextTest
{
    class MassTransitModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddMassTransit(busConfig =>
            {
                busConfig.AddBus(context => CreateBus(context, new RabbitSettings()));
                busConfig.AddConsumersFromNamespaceContaining<MemoryIssuesConsumer>();
                busConfig.AddConsumersFromNamespaceContaining<NoMemoryIssuesConsumer>();
            });
        }

        private static IBusControl CreateBus(IComponentContext context, RabbitSettings rabbitSettings) =>
            Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var rabbitUri = rabbitSettings.RabbitUri;
                var clusterMode = false;

                if (rabbitSettings.RabbitNodes != null && rabbitSettings.RabbitNodes.Length == 1)
                {
                    // there is only a single node listed, so rather than having a "UseCluster" with one node in the transport simply
                    // swap it out with the single node.
                    var rabbitUriBuilder = new UriBuilder(rabbitUri);
                    rabbitUriBuilder.Host = rabbitSettings.RabbitNodes[0];
                    rabbitUri = rabbitUriBuilder.Uri;
                }
                else if (rabbitSettings.RabbitNodes != null && rabbitSettings.RabbitNodes.Length > 0)
                {
                    // if we have multiple nodes, we're still using cluster mode.
                    clusterMode = true;
                }

                cfg.Host(rabbitUri, h =>
                {
                    h.Username(rabbitSettings.RabbitUserName);
                    h.Password(rabbitSettings.RabbitPassword);

                    if (clusterMode)
                    {
                        h.UseCluster(c =>
                        {
                            foreach (var node in rabbitSettings.RabbitNodes)
                            {
                                c.Node(node);
                            }
                        });
                    }
                });

                cfg.ConfigureEndpoints(context);
            });
    }
}
