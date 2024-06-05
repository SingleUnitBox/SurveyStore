using SurveyStore.Modules.SurveyJobs.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Decorators.Commands
{
    internal sealed class AddDocumentLoggerDecorator : ICommandHandler<AddDocument>
    {
        public Task HandleAsync(AddDocument command)
        {
            throw new System.NotImplementedException();
        }
    }
}
