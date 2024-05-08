using SurveyStore.Modules.Collections.Application.Clients.Equipment.Kit;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class KitCreatedHandler : IEventHandler<KitCreated>
    {
        private readonly IKitRepository _kitRepository;
        private readonly IKitApiClient _kitApiClient;

        public KitCreatedHandler(IKitRepository kitRepository)
        {
            _kitRepository = kitRepository;
        }

        public async Task HandleAsync(KitCreated @event)
        {
            var kit = await _kitRepository.GetAsync(@event.Id);
            if (kit is not null)
            {
                return;
            }

            kit = Kit.Create()
        }
    }
}
