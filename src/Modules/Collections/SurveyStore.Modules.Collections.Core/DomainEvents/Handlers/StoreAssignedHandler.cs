using SurveyStore.Shared.Abstractions.Kernel;
using System;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;

namespace SurveyStore.Modules.Collections.Core.DomainEvents.Handlers
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
            var collection = Collection.Create(Guid.NewGuid(), @event.SurveyEquipment.Id);
            collection.ChangeCollectionStoreId(@event.StoreId);

            await _collectionRepository.AddAsync(collection);
        }
    }
}
