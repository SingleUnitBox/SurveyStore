using Microsoft.Extensions.Logging;
using SurveyStore.Modules.Collections.Application.Events.External;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Infrastructure.Postgres.Decorators;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Decorators.Events
{
    //[Decorator]
    //internal sealed class KitCreatedHandlerDecorator : IEventHandler<KitCreated>
    //{
    //    private readonly IEventHandler<KitCreated> _eventHandler;
    //    private readonly ILogger<KitCreatedHandlerDecorator> _logger;

    //    public KitCreatedHandlerDecorator(IEventHandler<KitCreated> eventHandler,
    //        ILogger<KitCreatedHandlerDecorator> logger)
    //    {
    //        _eventHandler = eventHandler;
    //        _logger = logger;
    //    }
    //    public async Task HandleAsync(KitCreated @event)
    //    {
    //        await _eventHandler.HandleAsync(@event);
    //        _logger.LogInformation($"Created a kit with id '{@event.Id}'.");
    //    }
    //}
}
