using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Equipment.Application.Events.External
{
    public record SurveyorAdded(Guid Id, string FirstName, string Surname) : IEvent;
}
