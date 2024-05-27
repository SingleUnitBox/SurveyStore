using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Queries
{
    public record GetSurveyJobById(Guid Id) : IQuery<SurveyJobDto>;
}
