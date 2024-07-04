using Microsoft.Extensions.Logging;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Application.Events.External.Handlers
{
    internal sealed class CollectionCreatedHandler : IEventHandler<CollectionCreated>
    {
        private readonly ILogger<CollectionCreatedHandler> _logger;

        public CollectionCreatedHandler(ILogger<CollectionCreatedHandler> logger)
        {
            _logger = logger;
        }

        public async Task HandleAsync(CollectionCreated @event)
        {
            var collection = new
            {
                Id = @event.Id,
                SurveyequipmentId = @event.SurveyEquipmentId
            };

            await Task.Delay(10_000);
            _logger.LogInformation($"Collection with id '{collection.Id}' created.");
            
            await Task.CompletedTask;
        }
    }
}
