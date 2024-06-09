using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record AssignSurveyors(Guid SurveyJobId, params string[] Emails) : ICommand;
}
