using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Calibrations.Domain.Exceptions
{
    public class EmptyCalibrationStatusException : SurveyStoreException
    {
        public EmptyCalibrationStatusException()
            : base($"Calibration status is empty.")
        {
        }
    }
}
