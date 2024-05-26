using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Application.Queries
{
    public record BrowseSurveyJobsBySurveyor(string Email) : IQuery<IEnumerable<SurveyJobDto>>;
}
