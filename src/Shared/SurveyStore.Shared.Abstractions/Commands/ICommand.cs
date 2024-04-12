using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Shared.Abstractions.Commands
{
    public interface ICommand : IMessage
    {
    }

    public interface ICommand<JsonWebToken> : ICommand
    {
    }
}
