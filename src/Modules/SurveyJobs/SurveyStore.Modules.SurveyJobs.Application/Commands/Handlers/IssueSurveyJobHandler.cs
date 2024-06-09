using SurveyStore.Modules.SurveyJobs.Application.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Time;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers
{
    public class IssueSurveyJobHandler : ICommandHandler<IssueSurveyJob>
    {
        private readonly ISurveyJobRepository _surveyJobRepository;
        private readonly IClock _clock;

        public IssueSurveyJobHandler(ISurveyJobRepository surveyJobRepository,
            IClock clock)
        {
            _surveyJobRepository = surveyJobRepository;
            _clock = clock;
        }

        public async Task HandleAsync(IssueSurveyJob command)
        {
            var surveyJob = await _surveyJobRepository.GetByIdAsync(command.SurveyJobId);
            if (surveyJob is null)
            {
                throw new SurveyJobNotFoundException(command.SurveyJobId);
            }

            if (command.IssuedAt.HasValue)
            {
                surveyJob.ChangeIssuedAt(command.IssuedAt.Value);
            }
            else
            {
                surveyJob.ChangeIssuedAt(_clock.Current());
            }
            
            await _surveyJobRepository.UpdateAsync(surveyJob);
        }
    }
}
