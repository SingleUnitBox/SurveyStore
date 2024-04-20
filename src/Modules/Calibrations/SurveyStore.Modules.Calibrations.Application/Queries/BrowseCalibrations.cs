using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace SurveyStore.Modules.Calibrations.Application.Queries
{
    public record BrowseCalibrations : IQuery<IReadOnlyCollection<CalibrationDto>>;
}
