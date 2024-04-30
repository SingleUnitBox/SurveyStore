using SurveyStore.Modules.Calibrations.Domain.Entities;
using System;

namespace SurveyStore.Modules.Calibrations.Domain.DomainServices
{
    public interface ICalibrationService
    {
        void ChangeCalibrationDetails(Calibration calibration, DateTime calibrationDueDate, DateTime now);
    }
}
