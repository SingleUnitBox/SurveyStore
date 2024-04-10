using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Saga.Messages
{
    internal record SendWelcomeMessage(string Email, string FullName) : ICommand;
}
