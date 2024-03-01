using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Services
{
    public class AppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AppInitializer> _logger;

        public AppInitializer(IServiceProvider serviceProvider,
            ILogger<AppInitializer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting AppInitializer...");
            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(DbContext).IsAssignableFrom(t)
                && !t.IsInterface && t != typeof(DbContext));

            using var scope = _serviceProvider.CreateScope();
            {
                foreach (var dbContextType in dbContextTypes)
                {
                    var dbContext = _serviceProvider.GetRequiredService(dbContextType) as DbContext;
                    if (dbContext is null)
                    {
                        continue;
                    }
                    await dbContext.Database.MigrateAsync(cancellationToken);
                }
            }

            _logger.LogInformation("Finishing AppInitializer.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
