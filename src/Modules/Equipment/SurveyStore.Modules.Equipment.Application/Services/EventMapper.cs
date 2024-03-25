using SurveyStore.Modules.Equipment.Application.Events;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Collections.Generic;
using System.Linq;

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
