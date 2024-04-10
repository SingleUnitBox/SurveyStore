using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }

    //public interface IJsonCommandDispatcher
    //{
    //    Task<JsonWebToken> DispatchAsync<JsonWebToken>(ICommand<JsonWebToken> command);
    //}
}
