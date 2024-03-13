using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Messaging
{
    internal sealed  class InMemoryMessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;

        public InMemoryMessageBroker(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
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
            }

            await Task.WhenAll(tasks);
        }
    }
}
