using Microsoft.AspNetCore.Mvc.Routing;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class KitReadyForReturnHandler : IDomainEventHandler<KitReadyForReturn>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IClock _clock;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public KitReadyForReturnHandler(IKitCollectionRepository kitCollectionRepository,
            IStoreRepository storeRepository,
            IClock clock,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _storeRepository = storeRepository;
            _clock = clock;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task HandleAsync(KitReadyForReturn @event)
        {
            var kit = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsOpenKitCollectionById(@event.KitId));
            if (kit is null)
            {
                throw new OpenKitCollectionNotFoundException(@event.KitId);
            }

            var store = await _storeRepository.GetByIdAsync(@event.ReturnStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(@event.ReturnStoreId);
            }

            kit.Return(store.Id, _clock.Current());
            //_kitCollectionRepository.Attach(kit);
            await _kitCollectionRepository.UpdateAsync(kit);

            await _domainEventDispatcher.DispatchAsync(kit.Events.FirstOrDefault());
        }
    }
}
