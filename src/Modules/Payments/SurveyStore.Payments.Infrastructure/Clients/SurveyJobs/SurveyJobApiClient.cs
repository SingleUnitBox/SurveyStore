using SurveyStore.Modules.Payments.Application.Clients.SurveyJobs;
using SurveyStore.Modules.Payments.Application.Clients.SurveyJobs.DTO;
using SurveyStore.Modules.Payments.Infrastructure.Clients.SurveyJobs.Requests;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Payments.Infrastructure.Clients.SurveyJobs
{
    public class SurveyJobApiClient : ISurveyJobsApiClient
    {
        private readonly IModuleClient _moduleClient;

        public SurveyJobApiClient(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }

        public Task<SurveyJobDto> GetSurveyJobAsync(Guid id)
            => _moduleClient.SendAsync<SurveyJobDto>("surveyJobs/get",
                new GetSurveyJobById
                {
                    Id = id
                });
    }
}
