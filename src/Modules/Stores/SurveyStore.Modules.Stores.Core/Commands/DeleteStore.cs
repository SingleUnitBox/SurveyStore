using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Stores.Core.Commands
{
    public record DeleteStore(Guid Id) : ICommand;
}
