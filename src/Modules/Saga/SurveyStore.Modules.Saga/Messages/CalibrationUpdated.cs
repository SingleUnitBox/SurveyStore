using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Saga.Messages
{
    public record CalibrationUpdated(Guid SurveyEquipmentId, string CalibrationStatus) : IEvent;
}
