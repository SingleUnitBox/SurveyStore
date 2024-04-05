using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Surveyors.Core.Events.External.Handlers
{
    public record UserCreated(Guid Id, string Email) : IEvent;
}
