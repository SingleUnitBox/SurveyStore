using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Events
{
    public record SurveyEquipmentUpdated(Guid StoreId) : IEvent;
}
