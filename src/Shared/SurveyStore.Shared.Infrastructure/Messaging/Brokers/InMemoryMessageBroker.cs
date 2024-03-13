using Microsoft.Extensions.Logging;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyStore.Shared.Infrastructure.Messaging.Dispatchers;

namespace SurveyStore.Shared.Infrastructure.Messaging.Brokers
{
    internal sealed class InMemoryMessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;
        private readonly IAsyncMessageDispatcher _messageDispatcher;
        private readonly MessagingOptions _messagingOptions;
        private readonly ILogger<InMemoryMessageBroker> _logger;

        public InMemoryMessageBroker(IModuleClient moduleClient,
            IAsyncMessageDispatcher messageDispatcher,
            MessagingOptions messagingOptions,
            ILogger<InMemoryMessageBroker> logger)
        {
            _moduleClient = moduleClient;
            _messageDispatcher = messageDispatcher;
            _messagingOptions = messagingOptions;
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
                if (_messagingOptions.UseBackgroundDispatcher)
                {
                    await _messageDispatcher.PublishAsync(message);
                    continue;
                }

                tasks.Add(_moduleClient.PublishAsync(message));
                _logger.LogInformation($"Publishing message: {message.GetType().Name}");
            }

            await Task.WhenAll(tasks);
        }
    }
}
