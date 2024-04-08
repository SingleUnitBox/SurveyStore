using SurveyStore.Modules.Surveyors.Core.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System;

namespace SurveyStore.Modules.Surveyors.Core.DAL.Queries
{
    public record GetSurveyorById(Guid Id) : IQuery<SurveyorDto>;
}
