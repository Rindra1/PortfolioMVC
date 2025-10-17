using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PortfolioMVC.Services
{
    public class PingService : BackgroundService
    {
        private readonly ILogger<PingService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public PingService(ILogger<PingService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var client = _httpClientFactory.CreateClient();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var response = await client.GetAsync("https://rindra-dotnet-portfolio.onrender.com/api/health", stoppingToken);
                    _logger.LogInformation("Ping effectué : {StatusCode}", response.StatusCode);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erreur lors du ping");
                }

                // Attendre 5 minutes avant le prochain ping
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
