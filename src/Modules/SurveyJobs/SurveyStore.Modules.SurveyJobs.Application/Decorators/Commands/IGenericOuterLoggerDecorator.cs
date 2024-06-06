using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Decorators.Commands
{
    public interface IGenericOuterLoggerDecorator<TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
