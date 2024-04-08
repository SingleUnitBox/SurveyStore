using System;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Clients.Surveyors;
using SurveyStore.Modules.Collections.Application.Clients.Surveyors.DTO;
using SurveyStore.Modules.Collections.Infrastructure.Clients.Requests;
using SurveyStore.Shared.Abstractions.Modules;

namespace SurveyStore.Modules.Collections.Infrastructure.Clients
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
