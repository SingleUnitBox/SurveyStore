using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record CollectKit(Guid KitId, Guid SurveyorId) : ICommand;
}
