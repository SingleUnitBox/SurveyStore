using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Saga.Messages
{
    public record SurveyorCreated(Guid Id) : IEvent;
}
