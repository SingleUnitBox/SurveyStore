using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Saga.Messages
{
    public record CollectionUpdated(Guid SurveyEquipmentId, Guid StoreId) : IEvent;
}
