using SurveyStore.Modules.Calibrations.Application.Events;
using SurveyStore.Modules.Calibrations.Application.Exceptions;
using SurveyStore.Modules.Calibrations.Domain.DomainServices;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Application.Commands.Handlers
{
    public class CalibrateHandler : ICommandHandler<Calibrate>
    {
        private readonly ICalibrationsRepository _calibrationsRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IClock _clock;
        private readonly ICalibrationService _calibrationService;

        public CalibrateHandler(ICalibrationsRepository calibrationsRepository,
            IMessageBroker messageBroker,
            IClock clock,
            ICalibrationService calibrationService)
        {
            _calibrationsRepository = calibrationsRepository;
            _messageBroker = messageBroker;
            _clock = clock;
            _calibrationService = calibrationService;
        }

        public async Task HandleAsync(Calibrate command)
        {
            var calibration = await _calibrationsRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (calibration is null)
            {
                throw new CalibrationNotFoundException(command.SerialNumber);
            }

            calibration.ChangeCertificateNumber(command.CertificateNumber);          
            calibration.ChangeCalibrationDueDate(command.CalibrationDueDate, _clock.Current());     

            await _calibrationsRepository.UpdateAsync(calibration);
            //await _messageBroker.PublishAsync(new CalibrationUpdated(calibration.SurveyEquipmentId));
        }
    }
}
