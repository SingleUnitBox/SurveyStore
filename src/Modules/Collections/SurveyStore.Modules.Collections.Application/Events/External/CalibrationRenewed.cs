using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Collections.Application.Events.External
{
    public record CalibrationRenewed(Guid SurveyEquipmentId, string CalibrationStatus) : IEvent;
}
