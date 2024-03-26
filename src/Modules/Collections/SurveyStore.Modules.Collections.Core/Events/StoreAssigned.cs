﻿using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Events
{
    public record StoreAssigned(SurveyEquipment SurveyEquipment, StoreId StoreId) : IDomainEvent;

}
