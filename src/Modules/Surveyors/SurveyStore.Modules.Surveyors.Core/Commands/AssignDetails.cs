using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Surveyors.Core.Commands
{
    public record AssignSurveyorDetails(string Email, string FirstName, string Surname, string Position) : ICommand;
}
