using SurveyStore.Modules.Calibrations.Domain.Exceptions;
using SurveyStore.Shared.Abstractions.Types;
using System.Linq;

namespace SurveyStore.Modules.Calibrations.Domain.ValueObjects
{
    public record CalibrationStatus
    {
        public string Value { get; }

        public CalibrationStatus(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyCalibrationStatusException();
            }

            if (!CalibrationStatusTypes.GetCalibrationStatusTypes().Contains(value))
            {
                throw new InvalidCalibrationStatusException(value);
            }

            Value = value;
        }

        public static implicit operator string(CalibrationStatus calibrationStatus) => calibrationStatus.Value;
        public static implicit operator CalibrationStatus(string value) => new CalibrationStatus(value);
    }
}
