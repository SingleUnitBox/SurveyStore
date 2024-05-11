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
    public class KitCollectionCreatedHandler : IEventHandler<KitCollectionCreated>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;

        public KitCollectionCreatedHandler(IKitCollectionRepository kitCollectionRepository)
        {
            _kitCollectionRepository = kitCollectionRepository;
        }

        public async Task HandleAsync(KitCollectionCreated @event)
        {
            var kitCollections = await _kitCollectionRepository.
                BrowseKitCollectionsAsync(new AggregateId(@event.KitId));
            if (kitCollections.Any(k => k.CollectedAt is null
            && k.ReturnedAt is null
            && k.Surveyor is null))
            {
                throw new FreeKitCollectionAlreadyExistsException(@event.KitId);
            }

            var kitCollection = KitCollection.Create(Guid.NewGuid(), @event.KitId);
            kitCollection.ChangeCollectionStoreId(@event.CollectionStoreId);

            await _kitCollectionRepository.AddAsync(kitCollection);
        }
    }
}
