using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Linq;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class CreateCollectionHandler : IEventHandler<CreateCollection>
    {
        private readonly ICollectionRepository _collectionRepository;

        public CreateCollectionHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task HandleAsync(CreateCollection @event)
        {
            var collections = await _collectionRepository.BrowseCollectionsAsync(@event.SurveyEquipmentId);
            if (collections.Any(c => c.CollectedAt is null))
            {
                throw new FreeCollectionAlreadyExistsException(@event.SurveyEquipmentId);
            }

            var collection = Collection.Create(Guid.NewGuid(), @event.SurveyEquipmentId);
            collection.ChangeCollectionStoreId(@event.CollectionStoreId);
            
            await _collectionRepository.AddAsync(collection);
        }
    }
}

