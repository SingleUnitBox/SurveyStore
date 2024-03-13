using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBroker, InMemoryMessageBroker>();

            return services;
        }
    }
}
