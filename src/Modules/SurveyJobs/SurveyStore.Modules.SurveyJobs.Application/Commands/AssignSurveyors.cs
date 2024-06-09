using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record AssignSurveyors(Guid SurveyJobId, IEnumerable<string> SurveyorEmails) : ICommand;
}