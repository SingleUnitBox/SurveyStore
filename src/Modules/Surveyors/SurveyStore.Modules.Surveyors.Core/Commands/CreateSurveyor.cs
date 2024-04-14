using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Surveyors.Core.Commands
{
    public record CreateSurveyor(Guid Id, string Email, string FirstName, string Surname, string Position) : ICommand;

}
