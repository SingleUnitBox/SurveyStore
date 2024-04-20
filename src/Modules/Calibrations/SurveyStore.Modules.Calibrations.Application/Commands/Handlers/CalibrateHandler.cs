using SurveyStore.Modules.Calibrations.Application.Events;
using SurveyStore.Modules.Calibrations.Application.Exceptions;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Modules.Calibrations.Domain.Types;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Application.Commands.Handlers
{
    public class CalibrateHandler : ICommandHandler<Calibrate>
    {
        private readonly ICalibrationsRepository _calibrationsRepository;
        private readonly IMessageBroker _messageBroker;

        public CalibrateHandler(ICalibrationsRepository calibrationsRepository,
            IMessageBroker messageBroker)
        {
            _calibrationsRepository = calibrationsRepository;
            _messageBroker = messageBroker;
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
            calibration.ChangeCalibrationStatus(CalibrationStatus.Calibrated);

            await _calibrationsRepository.UpdateAsync(calibration);
            await _messageBroker.PublishAsync(new CalibrationUpdated(calibration.SurveyEquipmentId));
        }
    }
}
