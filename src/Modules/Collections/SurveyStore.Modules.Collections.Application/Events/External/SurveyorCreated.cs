using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Collections.Application.Events.External
{
    public record SurveyorCreated(Guid Id, string FirstName, string Surname) : IEvent;
}
