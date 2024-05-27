using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record AddSurveyJob(string Name, DateTime BriefIssued,
        DateTime DueDate, int? Budget, string SurveyType, IEnumerable<string> DocumentLinks = null,
        IEnumerable<string> SurveyorEmails = null) : ICommand
    {
        public Guid Id => Guid.NewGuid();
    }
}
