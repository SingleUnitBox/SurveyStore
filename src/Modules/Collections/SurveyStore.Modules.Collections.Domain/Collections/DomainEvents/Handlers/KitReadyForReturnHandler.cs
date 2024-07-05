using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class KitReadyForReturnHandler : IDomainEventHandler<KitReadyForReturn>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IClock _clock;

        public KitReadyForReturnHandler(IKitCollectionRepository kitCollectionRepository,
            IStoreRepository storeRepository,
            IClock clock)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _storeRepository = storeRepository;
            _clock = clock;
        }

        public async Task HandleAsync(KitReadyForReturn @event)
        {
            var kit = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsFreeKitCollectionById(@event.KitId));
            if (kit is null)
            {
                throw new FreeKitCollectionNotFoundException(@event.KitId);
            }

            var store = await _storeRepository.GetByIdAsync(@event.ReturnStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(@event.ReturnStoreId);
            }

            kit.Return(store.Id, _clock.Current());
            await _kitCollectionRepository.UpdateAsync(kit);

        }
    }
}
