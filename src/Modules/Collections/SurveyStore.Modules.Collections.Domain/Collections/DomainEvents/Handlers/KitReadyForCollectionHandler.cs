using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Time;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class KitReadyForCollectionHandler : IDomainEventHandler<KitReadyForCollection>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IClock _clock;

        public KitReadyForCollectionHandler(IKitCollectionRepository kitCollectionRepository,
            ISurveyorRepository surveyorRepository,
            IStoreRepository storeRepository,
            IClock clock)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _surveyorRepository = surveyorRepository;
            _storeRepository = storeRepository;
            _clock = clock;
        }

        public async Task HandleAsync(KitReadyForCollection @event)
        {
            var kit = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsFreeKitCollectionById(@event.KitId));
            if (kit is null)
            {
                throw new FreeKitCollectionNotFoundException(@event.KitId);
            }

            var surveyor = await _surveyorRepository.GetByIdAsync(@event.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(@event.SurveyorId);
            }

            var store = await _storeRepository.GetByIdAsync(@event.CollectionStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(@event.CollectionStoreId);
            }

            kit.Collect(surveyor, _clock.Current());
            await _kitCollectionRepository.UpdateAsync(kit);
        }
    }
}
