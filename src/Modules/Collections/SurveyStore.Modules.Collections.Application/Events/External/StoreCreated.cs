using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace SurveyStore.Modules.Collections.Application.Events.External
{
    [Message("stores")]
    public record StoreCreated(Guid Id) : IEvent;
}
