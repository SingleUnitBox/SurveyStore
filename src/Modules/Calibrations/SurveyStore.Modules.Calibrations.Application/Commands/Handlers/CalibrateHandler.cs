using SurveyStore.Modules.Calibrations.Application.Events;
using SurveyStore.Modules.Calibrations.Application.Exceptions;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Modules.Calibrations.Domain.Types;
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

        public CalibrateHandler(ICalibrationsRepository calibrationsRepository,
            IMessageBroker messageBroker,
            IClock clock)
        {
            _calibrationsRepository = calibrationsRepository;
            _messageBroker = messageBroker;
            _clock = clock;
        }

        public async Task HandleAsync(Calibrate command)
        {
            var calibration = await _calibrationsRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (calibration is null)
            {
                throw new CalibrationNotFoundException(command.SerialNumber);
            }

            calibration.ChangeCalibrationDueDate(command.CalibrationDueDate);
            calibration.ChangeCertificateNumber(command.CertificateNumber);
            
            var now = _clock.Current();
            var status = command.CalibrationDueDate.Date <= now
                ? CalibrationStatus.Uncalibrated
                : CalibrationStatus.Calibrated;
            if (command.CalibrationDueDate.Date < now.AddDays(3))
            {
                status = CalibrationStatus.ToBeReturnForCalibration;
            }
            calibration.ChangeCalibrationStatus(status);

            await _calibrationsRepository.UpdateAsync(calibration);
            await _messageBroker.PublishAsync(new CalibrationUpdated(calibration.SurveyEquipmentId));
        }
    }
}
