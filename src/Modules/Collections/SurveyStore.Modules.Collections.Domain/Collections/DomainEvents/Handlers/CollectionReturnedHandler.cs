using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Shared.Abstractions.Kernel;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class CollectionReturnedHandler : IDomainEventHandler<CollectionReturned>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;

        public CollectionReturnedHandler(ICollectionRepository collectionRepository,
            IStoreRepository storeRepository,
            ISurveyEquipmentRepository surveyEquipmentRepository)
        {
            _collectionRepository = collectionRepository;
            _storeRepository = storeRepository;
            _surveyEquipmentRepository = surveyEquipmentRepository;
        }

        public async Task HandleAsync(CollectionReturned @event)
        {
            var collection = await _collectionRepository
                .GetAsPredicateExpressionAsync(new IsFreeCollection(@event.SurveyEquipmentId));
            if (collection is not null)
            {
                return;
            }

            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(@event.SurveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(@event.SurveyEquipmentId);
            }

            var store = await _storeRepository.GetByIdAsync(@event.ReturnStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(@event.ReturnStoreId);
            }

            collection = Collection.Create(Guid.NewGuid(), surveyEquipment.Id);
            collection.AssignStore(store.Id);
            await _collectionRepository.AddAsync(collection);
        }
    }
}
