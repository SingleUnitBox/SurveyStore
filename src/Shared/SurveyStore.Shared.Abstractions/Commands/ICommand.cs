namespace SurveyStore.Shared.Abstractions.Commands
{
    public interface ICommand
    {
    }

    public interface ICommand<JsonWebToken> : ICommand
    {
    }
}
