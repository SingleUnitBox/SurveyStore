using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Infrastructure.Messaging.Brokers;
using SurveyStore.Shared.Infrastructure.Messaging.Dispatchers;

namespace SurveyStore.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBroker, InMemoryMessageBroker>();
            services.AddSingleton<IMessageChannel, MessageChannel>();
            services.AddSingleton<IAsyncMessageDispatcher, AsyncMessageDispatcher>();

            return services;
        }
    }
}
