using SurveyStore.Modules.SurveyJobs.Application.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers
{
    public class AddSurveyJobHandler : ICommandHandler<AddSurveyJob>
    {
        private readonly ISurveyJobRepository _surveyJobRepository;

        public AddSurveyJobHandler(ISurveyJobRepository surveyJobRepository)
        {
            _surveyJobRepository = surveyJobRepository;
        }

        public async Task HandleAsync(AddSurveyJob command)
        {
            var surveyJob = await _surveyJobRepository.GetByIdAsync(command.Id);
            if (surveyJob is not null)
            {
                throw new SurveyJobAlreadyExistsException(command.Id);
            }

            surveyJob = SurveyJob.Create(command.Id, command.BriefIssued, command.DueDate);

            await _surveyJobRepository.AddAsync(surveyJob);
        }
    }
}
