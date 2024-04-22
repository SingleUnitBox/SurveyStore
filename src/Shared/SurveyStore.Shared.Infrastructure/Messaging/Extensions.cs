using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Infrastructure.Messaging.Brokers;
using SurveyStore.Shared.Infrastructure.Messaging.Dispatchers;

namespace SurveyStore.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {
        private const string SectionName = "messaging";
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBroker, MessageBroker>();
            services.AddSingleton<IMessageChannel, MessageChannel>();
            services.AddSingleton<IAsyncMessageDispatcher, AsyncMessageDispatcher>();

            var options = services.GetOptions<MessagingOptions>(SectionName);
            services.AddSingleton(options);
            if (options.UseBackgroundDispatcher)
            {
                services.AddHostedService<BackgroundDispatcher>();
            }

            return services;
        }
    }
}
