using SurveyStore.Modules.Surveyors.Core.DTO;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Surveyors.Core.DAL.Queries
{
    public record GetSurveyorByEmail(string Email) : IQuery<SurveyorDto>;
}
