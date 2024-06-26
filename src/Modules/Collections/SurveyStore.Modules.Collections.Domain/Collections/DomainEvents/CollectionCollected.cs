﻿using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents
{
    public record CollectionCollected(SurveyEquipmentId SurveyEquipmentId, StoreId CollectionStoreId) : IDomainEvent;
}
