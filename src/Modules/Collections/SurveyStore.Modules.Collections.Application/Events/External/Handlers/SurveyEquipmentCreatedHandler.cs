using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class SurveyEquipmentCreatedHandler : IEventHandler<SurveyEquipmentCreated>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;

        public SurveyEquipmentCreatedHandler(ISurveyEquipmentRepository surveyEquipmentRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
        }

        public async Task HandleAsync(SurveyEquipmentCreated @event)
        {
            var equipment = await _surveyEquipmentRepository.GetBySerialNumberAsync(@event.SerialNumber);
            if (equipment is not null)
            {
                return;
            }

            equipment = SurveyEquipment.Create(@event.Id, @event.SerialNumber, @event.Brand, @event.Model, @event.Type);
            await _surveyEquipmentRepository.AddAsync(equipment);
        }
    }
}
