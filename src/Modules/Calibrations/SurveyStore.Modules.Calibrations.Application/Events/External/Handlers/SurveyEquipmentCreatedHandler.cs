using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;
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

            surveyEquipment = SurveyEquipment.Create(@event.Id, @event.Brand, @event.Model, @event.SerialNumber);
            await _surveyEquipmentRepository.AddAsync(surveyEquipment);

            var calibrationId = Guid.NewGuid();
            var calibration = Calibration.Create(calibrationId, surveyEquipment.Id);
            await _calibrationsRepository.AddAsync(calibration);
        }
    }
}
