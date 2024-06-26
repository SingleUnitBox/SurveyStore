using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class StoreAssignedHandler : IDomainEventHandler<StoreAssigned>
    {
        private readonly ICollectionRepository _collectionRepository;

        public StoreAssignedHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task HandleAsync(StoreAssigned @event)
        {
            //var surveyEquipmentId = new AggregateId(@event.SurveyEquipment.Id);
            //var collections = await _collectionRepository.BrowseCollectionsAsync(surveyEquipmentId);
            //var collection = collections.SingleOrDefault(c => !c.CollectedAt.HasValue);
            //if (collection is not null)
            //{
            //    collection.ChangeCollectionStoreId(@event.StoreId);
            //    await _collectionRepository.UpdateAsync(collection);
            //}
            //else
            //{
            //    collection = Collection.Create(Guid.NewGuid(), @event.SurveyEquipment.Id);
            //    collection.ChangeCollectionStoreId(@event.StoreId);

            //    await _collectionRepository.AddAsync(collection);
            //}
        }
    }
}
