using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Saga.Messages
{
    public record CalibrationRenewed(Guid SurveyEquipmentId, string CalibrationStatus) : IEvent;
}
