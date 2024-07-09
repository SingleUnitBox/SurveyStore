using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Saga.Messages
{
    public record CollectionReturnedDueCalibration(Guid SurveyEquipmentId, Guid ReturnStoreId) : IEvent;   
}
