using SurveyStore.Modules.SurveyJobs.Application.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers
{
    public class SetSurveyJobBudgetHandler : ICommandHandler<SetSurveyJobBudget>
    {
        private readonly ISurveyJobRepository _surveyJobRepository;

        public SetSurveyJobBudgetHandler(ISurveyJobRepository surveyJobRepository)
        {
            _surveyJobRepository = surveyJobRepository;
        }

        public async Task HandleAsync(SetSurveyJobBudget command)
        {
            var surveyJob = await _surveyJobRepository.GetByIdAsync(command.SurveyJobId);
            if (surveyJob is null)
            {
                throw new SurveyJobNotFoundException(command.SurveyJobId);
            }

            surveyJob.SetBudget(command.Budget);
            await _surveyJobRepository.UpdateAsync(surveyJob);
        }
    }
}