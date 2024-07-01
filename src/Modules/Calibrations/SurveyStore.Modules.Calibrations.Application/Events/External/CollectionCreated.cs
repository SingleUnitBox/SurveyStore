using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Events.External
{
    public record CollectionCreated(Guid Id, Guid SurveyEquipmentId) : IEvent;
}
