using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.SurveyJobs.Application.Queries
{
    public record GetSurveyJobByName(string Name) : IQuery<SurveyJobDto>;
}
