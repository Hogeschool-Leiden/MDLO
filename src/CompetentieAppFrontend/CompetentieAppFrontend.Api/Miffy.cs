using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Miffy.MicroServices.Host;

namespace CompetentieAppFrontend.Api
{
    [ExcludeFromCodeCoverage]
    public class Miffy : IHostedService
    {
        private readonly IMicroserviceHost _microserviceHost;
        private readonly ILogger<Miffy> _logger;

        public Miffy(IMicroserviceHost microserviceHost, ILogger<Miffy> logger)
        {
            _microserviceHost = microserviceHost;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _microserviceHost.Start();

            _logger.LogTrace("Microservice host started");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _microserviceHost.Dispose();

            _logger.LogTrace("Microservice host terminated");

            return Task.CompletedTask;
        }
    }
}