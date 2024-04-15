using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Events.External
{
    internal record SurveyEquipmentCreated(Guid Id, string SerialNumber, string Brand, string Model) : IEvent;
}
