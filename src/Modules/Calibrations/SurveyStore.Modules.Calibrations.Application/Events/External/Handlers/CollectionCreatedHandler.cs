using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Application.Events.External.Handlers
{
    internal sealed class CollectionCreatedHandler : IEventHandler<CollectionCreated>
    {
        public async Task HandleAsync(CollectionCreated @event)
        {
            var collection = new
            {
                Id = @event.Id,
                SurveyequipmentId = @event.SurveyEquipmentId
            };

            await Task.CompletedTask;
        }
    }
}
