using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Saga.Messages
{
    public record CollectionCreated(Guid Id, Guid SurveyEquipmentId) : IEvent;
}
