using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Modules;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    internal sealed class ModuleClient : IModuleClient
    {
        private readonly IModuleRegistry _registry;
        private readonly IModuleSerializer _serializer;

        public ModuleClient(IModuleRegistry registry,
            IModuleSerializer serializer)
        {
            _registry = registry;
            _serializer = serializer;
        }

        public async Task<TResult> SendAsync<TResult>(string path, object request) where TResult : class
        {
            var registration = _registry.GetRequestRegistration(path);
            if (registration is null)
            {
                throw new InvalidOperationException($"No action has been defined for path '{path}'.");
            }

            var receiverRequest = TranslateType(request, registration.RequestType);
            var result = await registration.Action(receiverRequest);

            return result is null ? null : TranslateType<TResult>(result);
        }

        public async Task PublishAsync(object message)
        {
            var key = message.GetType().Name;
            var registrations = _registry.GetBroadcastRegistration(key);

            var tasks = new List<Task>();
            foreach (var registration in registrations)
            {
                var action = registration.Action;
                var receiverMessage = TranslateType(message, registration.ReceiverType);

                tasks.Add(action(receiverMessage));
            }
            
            await Task.WhenAll(tasks);
        }

        private object TranslateType(object message, Type type)
            => _serializer.Deserialize(_serializer.Serialize(message), type);

        private TResultType TranslateType<TResultType>(object message)
            => _serializer.Deserialize<TResultType>(_serializer.Serialize(message));
    }
}
