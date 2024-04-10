using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Saga.Messages
{
    public record SignedIn(Guid Id) : IEvent;
}
