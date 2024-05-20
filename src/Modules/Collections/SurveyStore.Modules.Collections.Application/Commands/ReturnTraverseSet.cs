using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record ReturnTraverseSet(Guid SurveyEquipmentId, Guid SurveyorId, Guid ReturnStoreId) : ICommand;
}
