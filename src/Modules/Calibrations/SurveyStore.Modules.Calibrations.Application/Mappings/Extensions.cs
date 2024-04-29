using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Modules.Calibrations.Domain.Entities;

namespace SurveyStore.Modules.Calibrations.Application.Mappings
{
    public static class Extensions
    {
        public static CalibrationDto AsDto(this Calibration calibration)
            => new()
            {
                Id = calibration.Id,
                SurveyEquipmentId = calibration.SurveyEquipmentId,
                SerialNumber = calibration.SurveyEquipment?.SerialNumber,
                CalibrationDueDate = calibration.CalibrationDueDate,
                //CalibrationInterval = calibration.CalibrationInterval,
                CertificateNumber = calibration.CertificateNumber,
                CalibrationStatus = calibration.CalibrationStatus,
            };
    }
}
