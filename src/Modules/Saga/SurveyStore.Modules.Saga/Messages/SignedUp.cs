using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Saga.Messages
{
    public record SignedUp(Guid Id, string email) : IEvent;
}
