using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record CollectTraverseSet(Guid SurveyEquipmentId, Guid SurveyorId) : ICommand;
}
