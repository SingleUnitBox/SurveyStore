using System;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record ReturnSurveyEquipment(Guid SurveyEquipmentId, Guid SurveyorId, Guid ReturnStoreId) : ICommand;
}
