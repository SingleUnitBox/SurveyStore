using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record AssignStoreToKit(Guid KitId, Guid StoreId) : ICommand;
}
