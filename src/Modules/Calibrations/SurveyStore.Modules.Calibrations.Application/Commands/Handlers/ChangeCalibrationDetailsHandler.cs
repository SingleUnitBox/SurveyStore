using SurveyStore.Modules.Calibrations.Application.Events;
using SurveyStore.Modules.Calibrations.Application.Exceptions;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Application.Commands.Handlers
{
    internal sealed class ChangeCalibrationDetailsHandler : ICommandHandler<ChangeCalibrationDetails>
    {
        private readonly ICalibrationsRepository _calibrationsRepository;
        private readonly IMessageBroker _messageBroker;
        public ChangeCalibrationDetailsHandler(ICalibrationsRepository calibrationsRepository)
        {
            _calibrationsRepository = calibrationsRepository;
        }
        public async Task HandleAsync(ChangeCalibrationDetails command)
        {
            var calibration = await _calibrationsRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (calibration is null)
            {
                throw new CalibrationNotFoundException(command.SerialNumber);
            }

            if (command.CalibrationDueDate.HasValue)
            {
                calibration.ChangeCalibrationDueDate(command.CalibrationDueDate.Value);
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
