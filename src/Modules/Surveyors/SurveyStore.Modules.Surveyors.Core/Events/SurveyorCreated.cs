using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Surveyors.Core.Events
{
    public record SurveyorCreated(Guid Id, string FirstName, string Surname) : IEvent;
}
