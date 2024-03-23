using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using SurveyStore.Modules.Equipment.Application.Events;
using SurveyStore.Modules.Equipment.Core.Events;

namespace SurveyStore.Modules.Equipment.Application.Services
{
    public sealed class EventMapper : IEventMapper
    {
        public IMessage Map(IDomainEvent @event)
            => @event switch
            {
                StoreAssigned e => new SurveyEquipmentUpdated(e.StoreId),
                _ => null,
            };

        public IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> events)
            => events.Select(Map);
    }
}
