using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Kernel;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class KitCollectionReturnedHandler : IDomainEventHandler<KitCollectionReturned>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IKitRepository _kitRepository;

        public KitCollectionReturnedHandler(IKitCollectionRepository kitCollectionRepository,
            IStoreRepository storeRepository,
            IKitRepository kitRepository)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _storeRepository = storeRepository;
            _kitRepository = kitRepository;
        }

        public async Task HandleAsync(KitCollectionReturned @event)
        {
            var kitCollection = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsFreeKitCollectionById(@event.KitId));
            if (kitCollection is not null)
            {
                return;
            }

            var kit = await _kitRepository.GetByIdAsync(@event.KitId);
            if (kit is null)
            {
                throw new KitNotFoundException(@event.KitId);
            }

            var store = await _storeRepository.GetByIdAsync(@event.ReturnStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(@event.ReturnStoreId);
            }

            kitCollection = KitCollection.Create(Guid.NewGuid(), kit.Id);
            kitCollection.AssignStore(store.Id);

            await _kitCollectionRepository.AddAsync(kitCollection);
        }
    }
}