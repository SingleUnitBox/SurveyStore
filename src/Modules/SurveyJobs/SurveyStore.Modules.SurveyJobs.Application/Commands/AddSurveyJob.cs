using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record AddSurveyJob(Guid Id, DateTime BriefIssued,
        DateTime DueDate, string SurveyType) : ICommand;
}
