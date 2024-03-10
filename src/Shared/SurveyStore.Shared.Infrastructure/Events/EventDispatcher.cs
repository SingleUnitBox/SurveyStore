using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SurveyStore.Shared.Infrastructure.Events
{
    internal sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            using var scope = _serviceProvider.CreateScope();
            {
                var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();
                var tasks = handlers.Select(h => h.HandleAsync(@event));

                await Task.WhenAll(tasks);
            }
        }
    }
}
