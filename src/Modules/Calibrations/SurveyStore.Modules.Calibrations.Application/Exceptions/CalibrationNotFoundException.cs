using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Exceptions
{
    public class CalibrationNotFoundException : SurveyStoreException
    {
        public string SerialNumber { get; }
        public Guid SurveyEquipmentId { get; }

        public CalibrationNotFoundException(string serialNumber)
            : base($"Calibration for survey equipment with serial number '{serialNumber}' was not found.")
        {
            SerialNumber = serialNumber;
        }

        public CalibrationNotFoundException(Guid surveyEquipmentId)
            : base($"Calibration for survey equipment with serial number '{surveyEquipmentId}' was not found.")
        {
            SurveyEquipmentId = surveyEquipmentId;
        }
    }
}
