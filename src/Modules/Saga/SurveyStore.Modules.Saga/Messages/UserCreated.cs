using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Saga.Messages
{
    public record UserCreated(Guid Id, string Email) : IEvent;
}
