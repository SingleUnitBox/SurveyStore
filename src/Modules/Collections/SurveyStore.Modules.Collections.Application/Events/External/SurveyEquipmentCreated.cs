using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Collections.Application.Events.External
{
    public record SurveyEquipmentCreated(Guid Id, string SerialNumber, string Brand, string Model) : IEvent;
}
