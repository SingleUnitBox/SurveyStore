using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Surveyors.Core.Commands
{
    public record AssignDetails(string Email, string FirstName, string Surname, string Position) : ICommand;
}
