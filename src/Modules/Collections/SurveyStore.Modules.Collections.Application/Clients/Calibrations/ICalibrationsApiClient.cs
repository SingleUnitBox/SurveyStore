using SurveyStore.Modules.Collections.Application.Clients.Calibrations.DTO;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Clients.Calibrations
{
    public interface ICalibrationsApiClient
    {
        Task<CalibrationDto> GetCalibrationAsync(Guid surveyEquipmentId);
        Task<CalibrationDto> GetCalibrationAsync(string serialNumber);
    }
}
