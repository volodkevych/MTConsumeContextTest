using MassTransit;
using MTConsumeContextTest.Service;
using System.Threading.Tasks;

namespace MTConsumeContextTest.Consumer
{
    public class MemoryIssuesConsumer : IConsumer<IMemoryIssuesTriggerMessage>
    {
        private readonly IPublisher publisher;

        public MemoryIssuesConsumer(IPublisher publishService) => this.publisher = publishService;

        public Task Consume(ConsumeContext<IMemoryIssuesTriggerMessage> context)
            => this.publisher.PublishAsync(context);
    }
}
