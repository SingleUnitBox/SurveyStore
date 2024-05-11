using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using SurveyStore.Modules.Collections.Application.Events;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Modules.Collections.Domain.Collections.DomainEvents;

namespace SurveyStore.Modules.Collections.Application.Services
{
    public class EventMapper : IEventMapper
    {
        public IMessage Map(IDomainEvent domainEvent)
            => domainEvent switch
            {
                StoreAssigned de => new CollectionCreated(new SurveyEquipmentId(de.SurveyEquipment.Id.Value), de.StoreId),
                StoreAssignedToKit de => new KitCollectionCreated(new KitId(de.Kit.Id.Value), de.StoreId),
                _ => null
            };

        public IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> domainEvents)
            => domainEvents.Select(Map);
    }
}
