using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Modules.Calibrations.Domain.Types;
using SurveyStore.Shared.Abstractions.Time;
using System;

namespace SurveyStore.Modules.Calibrations.Domain.DomainServices
{
    internal class CalibrationService : ICalibrationService
    {
        public void ChangeCalibrationDetails(Calibration calibration, DateTime calibrationDueDate, DateTime now)
        {
            var status = calibrationDueDate.Date <= now.Date
                ? CalibrationStatus.Uncalibrated
                : CalibrationStatus.Calibrated;
            if (calibrationDueDate.Date < now.AddDays(3).Date)
            {
                status = CalibrationStatus.ToBeReturnForCalibration;
            }

            calibration.ChangeCalibrationDueDate(calibrationDueDate);
            calibration.ChangeCalibrationStatus(status);
        }
    }
}
