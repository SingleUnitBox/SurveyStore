using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace SurveyStore.Shared.Infrastructure.Messaging
{
    internal sealed  class InMemoryMessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;
        private readonly ILogger<InMemoryMessageBroker> _logger;

        public InMemoryMessageBroker(IModuleClient moduleClient,
            ILogger<InMemoryMessageBroker> logger)
        {
            _moduleClient = moduleClient;
            _logger = logger;
        }

        public async Task PublishAsync(params IMessage[] messages)
        {
            if (messages is null)
            {
                return;
            }

            messages = messages.Where(m => m is not null).ToArray();
            if (!messages.Any())
            {
                return;
            }

            var tasks = new List<Task>();
            foreach (var message in messages)
            {
                tasks.Add(_moduleClient.PublishAsync(message));
                _logger.LogInformation($"Publishing message: {message.GetType().Name}");
            }

            await Task.WhenAll(tasks);
        }
    }
}
