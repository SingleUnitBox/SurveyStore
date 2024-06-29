using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class KitCollectionUpdatedHandler : IEventHandler<KitCollectionUpdated>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;

        public KitCollectionUpdatedHandler(IKitCollectionRepository kitCollectionRepository)
        {
            _kitCollectionRepository = kitCollectionRepository;
        }

        public async Task HandleAsync(KitCollectionUpdated @event)
        {
            var kitCollection = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsFreeKitCollectionById(@event.KitId.Value));
            if (kitCollection is not null)
            {
                kitCollection.AssignStore(@event.CollectionStoreId);
                await _kitCollectionRepository.UpdateAsync(kitCollection);
            }
            else
            {
                kitCollection = KitCollection.Create(Guid.NewGuid(), @event.KitId);
                kitCollection.AssignStore(@event.CollectionStoreId);      
                await _kitCollectionRepository.AddAsync(kitCollection);
            }
        }
    }
}
