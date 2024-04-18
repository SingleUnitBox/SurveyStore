using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Queries
{
    public record GetCalibrationBySurveyEquipmentId(Guid SurveyEquipmentId) : IQuery<CalibrationDto>;
}
