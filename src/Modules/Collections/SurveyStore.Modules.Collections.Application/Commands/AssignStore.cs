﻿using System;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record AssignStore(Guid SurveyEquipmentId, Guid StoreId) : ICommand;
}
