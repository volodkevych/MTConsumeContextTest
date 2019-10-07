using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTConsumeContextTest.Consumer
{
    public class MemoryIssuesConsumerDefinition : ConsumerDefinition<MemoryIssuesConsumer>
    {
        public MemoryIssuesConsumerDefinition()
        {
            this.EndpointName = "memory_issues_queue";
        }

        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<MemoryIssuesConsumer> consumerConfigurator)
        {
            base.ConfigureConsumer(endpointConfigurator, consumerConfigurator);
        }
    }
}
