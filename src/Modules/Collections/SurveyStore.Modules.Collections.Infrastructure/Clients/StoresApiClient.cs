using SurveyStore.Modules.Collections.Application.Clients.Stores;
using SurveyStore.Modules.Collections.Application.Clients.Stores.DTO;
using SurveyStore.Modules.Collections.Infrastructure.Clients.Requests;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Infrastructure.Clients
{
    internal sealed class StoresApiClient : IStoresApiClient
    {
        private readonly IModuleClient _moduleClient;

        public StoresApiClient(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }
        public Task<StoreDto> GetStoreAsync(Guid id)
            => _moduleClient.SendAsync<StoreDto>("stores/get",
                new GetStore
                {
                    Id = id
                });
    }
}
