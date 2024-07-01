using SurveyStore.Shared.Abstractions.Moduless;
using SurveyStore.Shared.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Moduless
{
    internal sealed class ModulessClient : IModulessClient
    {
        private readonly IMyModuleRegistry _moduleRegistry;
        private readonly IModuleSerializer _moduleSerializer;
        public ModulessClient(IMyModuleRegistry moduleRegistry,
            IModuleSerializer moduleSerializer)
        {
            _moduleRegistry = moduleRegistry;
            _moduleSerializer = moduleSerializer;
        }
        public async Task PublishAsync(object message)
        {
            var key = message.GetType().Name;
            var registrations = _moduleRegistry.GetBroadcastRegistration(key);

            var tasks = new List<Task>();
            foreach (var registration in registrations)
            {
                // object > json > object
                // CollectionCreated > json > CollectionCreated
                var serializedEvent = _moduleSerializer.Serialize(message);
                var deserializedEvent = _moduleSerializer.Deserialize(serializedEvent, registration.ReceiverType);

                var receiverMessage = TranslateType(message, registration.ReceiverType);
                
                tasks.Add(registration.Action(receiverMessage));
            }

            await Task.WhenAll(tasks);
        }

        private object TranslateType(object message, Type type)
            => _moduleSerializer.Deserialize(_moduleSerializer.Serialize(message), type);
    }
}
