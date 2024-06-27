using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public record KitReturnedHandler : IEventHandler<KitReturned>
    {
        private readonly IKitRepository _kitRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public KitReturnedHandler(IKitRepository kitRepository,
            IStoreRepository storeRepository,
            IEventMapper eventMapper,
            IMessageBroker messageBroker)
        {
            _kitRepository = kitRepository;
            _storeRepository = storeRepository;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(KitReturned @event)
        {
            var kit = await _kitRepository.GetByIdAsync(@event.KitId.Value);
            if (kit is null)
            {
                throw new KitNotFoundException(@event.KitId);
            }

            var store = await _storeRepository.GetByIdAsync(@event.ReturnStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(@event.ReturnStoreId);
            }

            //kit.AssignStore(@event.ReturnStoreId);
            await _kitRepository.UpdateAsync(kit);

            //var events = _eventMapper.MapAll(kit.Events);
            //await _messageBroker.PublishAsync(events.ToArray());
        }
    }
}
