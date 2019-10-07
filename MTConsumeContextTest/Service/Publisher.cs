using System.Linq;
using System.Threading.Tasks;
using MassTransit;

namespace MTConsumeContextTest.Service
{
    class Publisher : IPublisher
    {
        public async Task PublishAsync(IPublishEndpoint publishEndpoint)
        {
            var ids = Enumerable.Range(1, 1000000);

            var publishTasks = ids.Select(id => publishEndpoint.Publish<ITestMessage>(new TestMessage(id)));

            foreach(var task in publishTasks)
            {
                await task;
            }

            //var batchSize = 100;
            //var batchesOfTasks = publishTasks
            //    .Select((task, index) => new { task, index })
            //    .GroupBy(x => x.index / batchSize)
            //    .Select(g => g.Select(x => x.task));

            //foreach (var batchOfTasks in batchesOfTasks)
            //{
            //    await Task.WhenAll(batchOfTasks);
            //}
        }

        private class TestMessage : ITestMessage
        {
            public TestMessage(int id) => this.Id = id;

            public int Id { get; }
        }
    }
}
