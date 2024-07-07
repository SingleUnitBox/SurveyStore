using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Application.Events.External.Handlers
{
    internal class SurveyEquipmentCreatedHandler : IEventHandler<SurveyEquipmentCreated>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly ICalibrationsRepository _calibrationsRepository;

        public SurveyEquipmentCreatedHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            ICalibrationsRepository calibrationsRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _calibrationsRepository = calibrationsRepository;
        }

        public async Task HandleAsync(SurveyEquipmentCreated @event)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetBySerialNumberAsync(@event.SerialNumber);
            if (surveyEquipment is not null)
            {
                return;
            }

            surveyEquipment = SurveyEquipment.Create(@event.SurveyEquipmentId, @event.Brand, @event.Model, @event.SerialNumber);
            await _surveyEquipmentRepository.AddAsync(surveyEquipment);

            var calibration = Calibration.Create(Guid.NewGuid(), @event.SurveyEquipmentId);
            await _calibrationsRepository.AddAsync(calibration);
        }
    }
}
