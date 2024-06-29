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
                CollectionCollected de => new SurveyEquipmentCollected(de.SurveyEquipmentId),
                CollectionReturned de => new SurveyEquipmentReturned(de.SurveyEquipmentId, de.ReturnStoreId),

                KitCollectionCollected de => new KitCollected(de.KitId),
                KitCollectionReturned de => new KitReturned(de.KitId, de.ReturnStoreId),
                _ => null
            };

        public IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> domainEvents)
            => domainEvents.Select(Map);
    }
}