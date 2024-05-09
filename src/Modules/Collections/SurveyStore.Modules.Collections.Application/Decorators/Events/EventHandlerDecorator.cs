using Microsoft.Extensions.Logging;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Infrastructure.Postgres.Decorators;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Decorators.Events
{
    [Decorator]
    internal sealed class EventHandlerDecorator<TEvent> : IEventHandler<TEvent>
        where TEvent : class, IEvent
    {
        private readonly IEventHandler<TEvent> _eventHandler;
        private readonly ILogger<EventHandlerDecorator<TEvent>> _logger;

        public EventHandlerDecorator(IEventHandler<TEvent> eventHandler,
            ILogger<EventHandlerDecorator<TEvent>> logger)
        {
            _eventHandler = eventHandler;
            _logger = logger;
        }

        public async Task HandleAsync(TEvent @event)
        {
            await _eventHandler.HandleAsync(@event);
            _logger.LogInformation($"Finishing processing event '{@event.GetType().Name}'.");
        }
    }
}
