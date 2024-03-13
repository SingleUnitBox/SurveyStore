using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SurveyStore.Shared.Abstractions.Modules;

namespace SurveyStore.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class BackgroundDispatcher : BackgroundService
    {
        private readonly IModuleClient _moduleClient;
        private readonly IMessageChannel _messageChannel;
        private readonly ILogger<BackgroundDispatcher> _logger;

        public BackgroundDispatcher(IModuleClient moduleClient,
            IMessageChannel messageChannel,
            ILogger<BackgroundDispatcher> logger)
        {
            _moduleClient = moduleClient;
            _messageChannel = messageChannel;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Running the background dispatcher.");

            await foreach (var message in _messageChannel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await _moduleClient.PublishAsync(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            _logger.LogInformation("Finished running the background dispatcher");
        }
    }
}
