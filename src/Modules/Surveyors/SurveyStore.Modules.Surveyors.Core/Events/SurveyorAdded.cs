using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Surveyors.Core.Events
{
    public record SurveyorAdded(Guid Id, string Email, string FirstName, string Surname) : IEvent;
}
