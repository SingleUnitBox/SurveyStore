using System;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record CollectSurveyEquipment(Guid SurveyEquipmentId, Guid SurveyorId) : ICommand;
}
