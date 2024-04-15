using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Calibrations.Domain.Exceptions
{
    public class InvalidCalibrationDateException : SurveyStoreException
    {
        public DateTime CalibrationDate { get; }
        public InvalidCalibrationDateException(DateTime calibrationDate)
            : base($"Calibration date '{calibrationDate.Date.ToShortDateString()}' is invalid.")
        {
            CalibrationDate = calibrationDate;
        }
    }
}
