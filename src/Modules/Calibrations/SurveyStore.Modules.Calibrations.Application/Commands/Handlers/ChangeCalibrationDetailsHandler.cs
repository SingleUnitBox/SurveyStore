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
    internal sealed class ChangeCalibrationDetailsHandler : ICommandHandler<ChangeCalibrationDetails>
    {
        private readonly ICalibrationsRepository _calibrationsRepository;
        private readonly IClock _clock;
        private readonly IMessageBroker _messageBroker;
        public ChangeCalibrationDetailsHandler(ICalibrationsRepository calibrationsRepository,
            IMessageBroker messageBroker,
            IClock clock)
        {
            _calibrationsRepository = calibrationsRepository;
            _messageBroker = messageBroker;
            _clock = clock;
        }
        public async Task HandleAsync(ChangeCalibrationDetails command)
        {
            var calibration = await _calibrationsRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (calibration is null)
            {
                throw new CalibrationNotFoundException(command.SerialNumber);
            }

            calibration.ChangeCalibrationDueDate(command.CalibrationDueDate);
            if (command.CalibrationDueDate < _clock.Current())
            {
                calibration.ChangeCalibrationStatus(CalibrationStatus.ToBeReturnForCalibration);
            }
            else
            {
                calibration.ChangeCalibrationStatus(CalibrationStatus.Calibrated);
            }
            

            //if (command.CalibrationInterval.HasValue)
            //{
            //    calibration.ChangeCalibrationInterval(command.CalibrationInterval.Value);
            //}

            if (!string.IsNullOrWhiteSpace(command.CertificateNumber))
            {
                calibration.ChangeCertificateNumber(command.CertificateNumber);
            }

            //if (command.CalibrationStatus.HasValue)
            //{
            //    calibration.ChangeCalibrationStatus(command.CalibrationStatus.Value);
            //}

            await _calibrationsRepository.UpdateAsync(calibration);
            await _messageBroker.PublishAsync(new CalibrationUpdated(calibration.SurveyEquipmentId));
        }
    }
}
