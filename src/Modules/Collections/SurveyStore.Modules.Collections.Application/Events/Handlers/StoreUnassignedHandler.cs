using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class StoreUnassignedHandler : IEventHandler<StoreUnassigned>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;

        public StoreUnassignedHandler(ISurveyEquipmentRepository surveyEquipmentRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
        }

        public async Task HandleAsync(StoreUnassigned @event)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(@event.SurveyEquipmentId.Value);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(@event.SurveyEquipmentId);
            }

            surveyEquipment.UnassignStore();
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);
        }
    }
}
