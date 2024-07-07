using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Events.External
{
    internal record SurveyEquipmentCreated(Guid SurveyEquipmentId, string SerialNumber, string Brand, string Model, string Type) : IEvent;
}
