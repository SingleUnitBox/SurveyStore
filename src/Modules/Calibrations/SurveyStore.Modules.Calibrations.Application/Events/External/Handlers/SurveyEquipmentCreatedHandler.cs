using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Application.Events.External.Handlers
{
    internal class SurveyEquipmentCreatedHandler : IEventHandler<SurveyEquipmentCreated>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;

        public SurveyEquipmentCreatedHandler(ISurveyEquipmentRepository surveyEquipmentRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
        }

        public async Task HandleAsync(SurveyEquipmentCreated @event)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(@event.Id);
            if (surveyEquipment is not null)
            {
                return;
            }

            surveyEquipment = SurveyEquipment.Create(@event.Id, @event.Brand, @event.Model, @event.SerialNumber);
            await _surveyEquipmentRepository.AddAsync(surveyEquipment);
        }
    }
}
