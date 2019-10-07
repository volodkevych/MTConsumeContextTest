using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace MTConsumeContextTest.Consumer
{
    public class NoMemoryIssuesConsumerDefinition : ConsumerDefinition<NoMemoryIssuesConsumer>
    {
        public NoMemoryIssuesConsumerDefinition()
        {
            this.EndpointName = "no_memory_issues_queue";
        }

        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<NoMemoryIssuesConsumer> consumerConfigurator)
        {
            base.ConfigureConsumer(endpointConfigurator, consumerConfigurator);
        }
    }
}
