using SurveyStore.Modules.Payments.Application.Clients.SurveyJobs;
using SurveyStore.Modules.Payments.Application.Exceptions;
using SurveyStore.Modules.Payments.Domain.Entities;
using SurveyStore.Modules.Payments.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Payments.Application.Events.External.Handlers
{
    public class SurveyJobCreatedHandler : IEventHandler<SurveyJobCreated>
    {
        private readonly ISurveyJobRepository _surveyJobRepository;
        private readonly ISurveyJobsApiClient _surveyJobsApiClient;

        public SurveyJobCreatedHandler(ISurveyJobRepository surveyJobRepository,
            ISurveyJobsApiClient surveyJobsApiClient)
        {
            _surveyJobRepository = surveyJobRepository;
            _surveyJobsApiClient = surveyJobsApiClient;
        }
        public async Task HandleAsync(SurveyJobCreated @event)
        {
            var surveyJob = await _surveyJobRepository.GetByIdAsync(@event.Id);
            if (surveyJob is not null)
            {
                return;
            }

            var surveyJobDto = await _surveyJobsApiClient.GetSurveyJobAsync(@event.Id);
            if (surveyJobDto is null)
            {
                throw new SurveyJobNotFoundException(@event.Id);
            }
            surveyJob = SurveyJob.Create(@event.Id, surveyJobDto.Name, surveyJobDto.IssuedAt,
                surveyJobDto.Budget, surveyJobDto.CostToDeliver);

            await _surveyJobRepository.AddAsync(surveyJob);
        }
    }
}