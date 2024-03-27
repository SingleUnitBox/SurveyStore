using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using SurveyStore.Modules.Collections.Application.Events;
using SurveyStore.Modules.Collections.Core.DomainEvents;

namespace SurveyStore.Modules.Collections.Application.Services
{
    public class EventMapper : IEventMapper
    {
        public IMessage Map(IDomainEvent domainEvent)
            => domainEvent switch
            {
                StoreAssigned de => new CreateCollection(de.SurveyEquipment, de.StoreId),
                _ => null
            };

        public IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> domainEvents)
            => domainEvents.Select(Map);
    }
}
