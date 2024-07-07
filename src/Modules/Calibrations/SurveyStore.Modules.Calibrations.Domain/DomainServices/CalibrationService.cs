using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Shared.Abstractions.Types;
using System;

namespace SurveyStore.Modules.Calibrations.Domain.DomainServices
{
    internal class CalibrationService : ICalibrationService
    {
        public void ChangeCalibrationDetails(Calibration calibration, DateTime calibrationDueDate, DateTime now)
        {
            var status = calibrationDueDate.Date <= now.Date
                ? CalibrationStatuses.Uncalibrated
                : CalibrationStatuses.Calibrated;
            if (calibrationDueDate.Date < now.AddDays(3).Date)
            {
                status = CalibrationStatuses.CalibrationDue;
            }

            //calibration.ChangeCalibrationDueDate(calibrationDueDate);
            //calibration.ChangeCalibrationStatus(status);
        }
    }
}
