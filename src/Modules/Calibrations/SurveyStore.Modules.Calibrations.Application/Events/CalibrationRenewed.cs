using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Events
{
    public record CalibrationRenewed(Guid SurveyEquipmentId, string CalibrationStatus) : IEvent;
}
