using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Services.Stores.Core.Commands
{
    public record UpdateStore(Guid Id, DateTime OpeningTime, DateTime ClosingTime) : ICommand;
}
