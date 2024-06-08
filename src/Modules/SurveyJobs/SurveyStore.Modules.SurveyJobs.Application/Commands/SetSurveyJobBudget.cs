using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record SetSurveyJobBudget(Guid SurveyJobId, int Budget) : ICommand;
}
