using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Collections.Application.Events.External
{
    public record CalibrationUpdated(Guid SurveyEquipmentId) : IEvent;
}
