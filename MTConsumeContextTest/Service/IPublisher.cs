using System;
using System.Threading.Tasks;
using MassTransit;

namespace MTConsumeContextTest.Service
{
    public interface IPublisher
    {
        Task PublishAsync(IPublishEndpoint publishEndpoint);
    }
}
