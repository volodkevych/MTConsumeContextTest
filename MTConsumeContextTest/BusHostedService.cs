using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace MTConsumeContextTest
{
    class BusHostedService : IHostedService
    {
        private readonly IBusControl busControl;

        public BusHostedService(IBusControl busControl) => this.busControl = busControl;

        public Task StartAsync(CancellationToken cancellationToken) => this.busControl.StartAsync(cancellationToken);

        public Task StopAsync(CancellationToken cancellationToken) => this.busControl.StopAsync();
    }
}
