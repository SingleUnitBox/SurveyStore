using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Calibrations.Domain.Exceptions
{
    public class InvalidCalibrationStatusException : SurveyStoreException
    {
        public string CalibrationStatus { get; }
        public InvalidCalibrationStatusException(string calibrationStatus)
            : base($"Calibration status of '' is invalid.")
        {
            CalibrationStatus = calibrationStatus;
        }
    }
}
