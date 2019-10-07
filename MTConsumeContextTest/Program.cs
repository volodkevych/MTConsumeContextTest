using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MTConsumeContextTest.Service;
using System.Threading.Tasks;

namespace MTConsumeContextTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureServices(collection => collection.AddHostedService<BusHostedService>())
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(builder => Builder = builder))
                .ConfigureContainer<ContainerBuilder>((context, builder) => 
                { 
                    builder.RegisterModule<MassTransitModule>();
                    builder.RegisterType<Publisher>().AsImplementedInterfaces();
                })
                .UseConsoleLifetime()
                .Build();

            await host.RunAsync();
        }

        public static ContainerBuilder Builder { get; private set; }
    }
}
