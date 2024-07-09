using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Events.External
{
    public record CollectionReturnedDueCalibration(Guid SurveyEquipmentId, Guid ReturnStoreId) : IEvent;
}
