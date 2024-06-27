using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Kernel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class StoreAssignedToKitHandler : IDomainEventHandler<StoreAssignedToKit>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;

        public StoreAssignedToKitHandler(IKitCollectionRepository kitCollectionRepository)
        {
            _kitCollectionRepository = kitCollectionRepository;
        }

        public async Task HandleAsync(StoreAssignedToKit @event)
        {
            //var kitCollections = await _kitCollectionRepository.BrowseKitCollectionsAsync(@event.Kit.Id);
            //var kitCollection = kitCollections.SingleOrDefault(k => !k.CollectedAt.HasValue);
            var kitCollection = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsFreeKitCollection(@event.Kit.Id));
            if (kitCollection is not null)
            {
                kitCollection.AssignStore(@event.StoreId);
                await _kitCollectionRepository.UpdateAsync(kitCollection);
            }
            else
            {
                kitCollection = KitCollection.Create(Guid.NewGuid(), @event.Kit.Id);
                kitCollection.AssignStore(@event.StoreId);

                await _kitCollectionRepository.AddAsync(kitCollection);
            }
        }
    }
}
