using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Stores.Core.Commands
{
    public record UpdateStore(Guid Id, DateTime OpeningTime, DateTime ClosingTime) : ICommand;
}
