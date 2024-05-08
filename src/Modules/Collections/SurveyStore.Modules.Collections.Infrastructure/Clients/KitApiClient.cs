using SurveyStore.Modules.Collections.Application.Clients.Equipment.Kit;
using SurveyStore.Modules.Collections.Application.Clients.Equipment.Kit.DTO;
using SurveyStore.Modules.Collections.Infrastructure.Clients.Requests;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Infrastructure.Clients
{
    internal sealed class KitApiClient : IKitApiClient
    {
        private readonly IModuleClient _moduleClient;

        public KitApiClient(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }

        public Task<KitDto> GetKitAsync(Guid kitId)
            => _moduleClient.SendAsync<KitDto>("kit/get",
                new GetKit(kitId));
    }
}
