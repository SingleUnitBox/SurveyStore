using SurveyStore.Modules.Collections.Application.Clients.Equipment.Kit;
using SurveyStore.Modules.Collections.Application.Exceptions;
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

        public KitCreatedHandler(IKitRepository kitRepository,
            IKitApiClient kitApiClient)
        {
            _kitRepository = kitRepository;
            _kitApiClient = kitApiClient;
        }

        public async Task HandleAsync(KitCreated @event)
        {
            var kit = await _kitRepository.GetByIdAsync(@event.Id);
            if (kit is not null)
            {
                return;
            }

            var kitDto = await _kitApiClient.GetKitAsync(@event.Id);
            if (kitDto is null)
            {
                throw new KitNotFoundException(@event.Id);
            }

            kit = Kit.Create(kitDto.Id, kitDto.Brand, kitDto.Model, kitDto.SerialNumber, kitDto.Type);
            await _kitRepository.AddAsync(kit);
        }
    }
}
