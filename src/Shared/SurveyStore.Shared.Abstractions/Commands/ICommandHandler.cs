using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }

    public interface ICommandHandler<in TCommand, JsonWebToken> where TCommand : class, ICommand<JsonWebToken>
    {
        Task<JsonWebToken> HandleAsync(TCommand command);
    }
}
