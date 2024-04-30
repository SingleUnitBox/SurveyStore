using SurveyStore.Modules.Calibrations.Domain.Entities;
using System;

namespace SurveyStore.Modules.Calibrations.Domain.DomainServices
{
    public interface ICalibrationService
    {
        bool ChangeCalibrationDetails(Calibration calibration, DateTime now);
    }
}
