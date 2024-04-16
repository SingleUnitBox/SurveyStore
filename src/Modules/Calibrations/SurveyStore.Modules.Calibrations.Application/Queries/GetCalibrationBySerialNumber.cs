using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Calibrations.Application.Queries
{
    public record GetCalibrationBySerialNumber(string SerialNumber) : IQuery<CalibrationDto>;
}
