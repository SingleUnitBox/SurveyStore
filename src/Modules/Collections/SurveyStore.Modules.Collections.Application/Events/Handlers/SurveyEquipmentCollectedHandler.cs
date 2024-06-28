using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class SurveyEquipmentCollectedHandler : IEventHandler<SurveyEquipmentCollected>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;

        public SurveyEquipmentCollectedHandler(ISurveyEquipmentRepository surveyEquipmentRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
        }

        public async Task HandleAsync(SurveyEquipmentCollected @event)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(@event.SurveyEquipmentId.Value);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(@event.SurveyEquipmentId);
            }

            //surveyEquipment.UnassignStore();
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);
        }
    }
}
