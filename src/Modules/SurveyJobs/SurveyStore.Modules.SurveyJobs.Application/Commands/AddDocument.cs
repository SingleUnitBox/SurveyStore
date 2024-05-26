using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record AddDocument(string DocumentType, string Link) : ICommand
    {
        public Guid Id => Guid.NewGuid();
    }
}
