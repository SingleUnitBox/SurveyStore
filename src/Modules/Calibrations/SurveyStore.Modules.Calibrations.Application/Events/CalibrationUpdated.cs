using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Events
{
    public record CalibrationUpdated(Guid SurveyEquipmentId, string CalibrationStatus) : IEvent;
}
