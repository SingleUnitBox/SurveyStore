using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record IssueSurveyJob(Guid SurveyJobId, DateTime? IssuedAt) : ICommand;
}
