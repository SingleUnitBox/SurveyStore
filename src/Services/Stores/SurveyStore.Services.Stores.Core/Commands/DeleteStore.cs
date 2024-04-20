using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Services.Stores.Core.Commands
{
    public record DeleteStore(Guid Id) : ICommand;
}
