﻿using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Application.Events
{
    public record CollectionUpdated(Guid SurveyEquipmentId, Guid StoreId) : IEvent;
}
