﻿using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents
{
    public record KitReadyForReturn(KitId KitId, StoreId ReturnStoreId) : IDomainEvent;
}
