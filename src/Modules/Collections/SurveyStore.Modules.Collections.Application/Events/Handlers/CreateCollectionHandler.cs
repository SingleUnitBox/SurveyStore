using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;

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
            var collection = Collection.Create(Guid.NewGuid(), @event.SurveyEquipment.Id);
            collection.ChangeCollectionStoreId(@event.CollectionStoreId);

            await _collectionRepository.AddAsync(collection);
        }
    }
}
