using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class CollectionCreatedHandler : IEventHandler<CollectionCreated>
    {
        private readonly ICollectionRepository _collectionRepository;

        public CollectionCreatedHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task HandleAsync(CollectionCreated @event)
        {
            var collection = await _collectionRepository.GetFreeBySurveyEquipmentAsync(new AggregateId(@event.SurveyEquipmentId));
            //var collections = await _collectionRepository.BrowseCollectionsAsync(new AggregateId(@event.SurveyEquipmentId));
            //if (collections.Any(c => c.CollectedAt is null
            //&& c.ReturnedAt is null
            //&& c.Surveyor is null))
            if (collection is not null)
            {
                throw new FreeCollectionAlreadyExistsException(@event.SurveyEquipmentId);
            }

            collection = Collection.Create(Guid.NewGuid(), @event.SurveyEquipmentId);
            collection.ChangeCollectionStoreId(@event.CollectionStoreId);
            
            await _collectionRepository.AddAsync(collection);
        }
    }
}