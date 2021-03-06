using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ServiceBusTrigger;
using ServiceBusTrigger.Application.Interfaces;
using ServiceBusTrigger.Application.Services;

[assembly: FunctionsStartup(typeof(Startup))]

namespace ServiceBusTrigger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IQueueService>((s) =>
            {
                return new QueueService();
            });
        }
    }
}