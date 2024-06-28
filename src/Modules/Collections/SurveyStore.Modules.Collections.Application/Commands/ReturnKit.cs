using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record ReturnKit(Guid KitId, Guid SurveyorId, Guid ReturnStoreId) : ICommand;
}
