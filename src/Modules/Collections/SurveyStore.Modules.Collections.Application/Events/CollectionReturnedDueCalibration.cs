using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Collections.Application.Events
{
    public record CollectionReturnedDueCalibration(Guid SurveyEquipmentId, Guid ReturnStoreId) : IEvent;
}
