using Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSPattern.App
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var userQuery = scope.ServiceProvider.GetService<IUserQuery>();
                
                while (!stoppingToken.IsCancellationRequested)
                {
                    var users = await userQuery.GetAllAsync();
                    _logger.LogInformation($"Number of active users: {users.Count}");
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
        }
    }
}