using MassTransit;
using MTConsumeContextTest.Service;
using System.Threading.Tasks;

namespace MTConsumeContextTest.Consumer
{
    public class NoMemoryIssuesConsumer : IConsumer<INoMemoryIssuesTriggerMessage>
    {
        private readonly IPublisher publisher;
        private readonly IBus bus;

        public NoMemoryIssuesConsumer(IPublisher publishService, IBus bus)
        {
            this.publisher = publishService;
            this.bus = bus;
        }

        public Task Consume(ConsumeContext<INoMemoryIssuesTriggerMessage> context)
            => this.publisher.PublishAsync(bus); // <- BUS, not context used !!!
    }
}
