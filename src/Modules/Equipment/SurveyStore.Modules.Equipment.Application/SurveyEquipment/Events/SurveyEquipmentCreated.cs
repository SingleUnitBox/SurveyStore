﻿using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Events
{
    public record SurveyEquipmentCreated(Guid Id, string SerialNumber, string Brand, string Model, string Type) : IEvent;
}
