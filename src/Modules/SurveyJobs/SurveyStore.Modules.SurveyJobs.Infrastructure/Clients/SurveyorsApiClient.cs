using SurveyStore.Modules.SurveyJobs.Application.Clients.Surveyors;
using SurveyStore.Modules.SurveyJobs.Application.Clients.Surveyors.DTO;
using SurveyStore.Modules.SurveyJobs.Infrastructure.Clients.Requests;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.Clients
{
    internal sealed class SurveyorsApiClient : ISurveyorsApiClient
    {
        private readonly IModuleClient _moduleClient;

        public SurveyorsApiClient(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }

        public Task<SurveyorDto> GetSurveyorAsync(Guid id)
            => _moduleClient.SendAsync<SurveyorDto>("surveyors/get",
                new GetSurveyorById
                {
                    Id = id
                });
    }
}
