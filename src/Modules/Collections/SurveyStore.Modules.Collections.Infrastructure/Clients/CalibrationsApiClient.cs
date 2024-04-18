using SurveyStore.Modules.Collections.Application.Clients.Calibrations;
using SurveyStore.Modules.Collections.Application.Clients.Calibrations.DTO;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Infrastructure.Clients
{
    internal sealed class CalibrationsApiClient : ICalibrationsApiClient
    {
        private readonly IModuleClient _moduleClient;
        public CalibrationsApiClient(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }
        public Task<CalibrationDto> GetCalibrationAsync(Guid surveyEquipmentId)
            => _moduleClient.SendAsync<CalibrationDto>("calibrations/get",
                new
                {
                    SurveyEquipmentId = surveyEquipmentId,
                });

        public Task<CalibrationDto> GetCalibrationAsync(string serialNumber)
            => _moduleClient.SendAsync<CalibrationDto>("calibrations/get",
                new
                {
                    SerialNumber = serialNumber,
                });
    }
}
