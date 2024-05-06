using System.Collections.Generic;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Services
{
    public interface IEventMapper
    {
        IMessage Map(IDomainEvent @event);
        IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> events);
    }
}
