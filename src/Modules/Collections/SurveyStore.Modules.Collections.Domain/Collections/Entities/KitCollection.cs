using SurveyStore.Modules.Collections.Domain.Collections.DomainEvents;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class KitCollection : AggregateRoot
    {
        public Kit Kit { get; private set; }
        public KitId KitId { get; private set; }
        public Surveyor Surveyor { get; private set; }
        public StoreId CollectionStoreId { get; private set; }
        public StoreId ReturnStoreId { get; private set; }
        public Date CollectedAt { get; private set; }
        public Date ReturnedAt { get; private set; }

        internal KitCollection(AggregateId id, KitId kitId)
        {
            Id = id;
            KitId = kitId;
        }

        public void AssignStore(StoreId storeId)
        {
            if (CollectionStoreId == storeId)
            {
                return;
            }
            CollectionStoreId = storeId;
            IncrementVersion();
        }

        public void CheckForCollection(SurveyorId surveyorId, StoreId collectionStoreId)
        {
            AddEvent(new KitReadyForCollection(KitId, surveyorId, collectionStoreId));
        }

        public void Collect(Surveyor surveyor, DateTime collectedAt)
        {
            if (CollectionStoreId is null)
            {
                throw new KitNotFoundInStoreException(Id);
            }
            Surveyor = surveyor;
            CollectedAt = collectedAt;
            IncrementVersion();
        }

        public void CheckForReturn(StoreId returnStoreId)
        {
            AddEvent(new KitReadyForReturn(KitId, returnStoreId));
        }

        public void Return(StoreId returnStoreId, DateTime returnedAt)
        {
            ReturnStoreId = returnStoreId;
            ReturnedAt = returnedAt;
            AddEvent(new KitCollectionReturned(KitId, ReturnStoreId));
        }

        public static KitCollection Create(Guid id, Guid kitId)
        {
            var kitCollection = new KitCollection(id, kitId);

            kitCollection.ClearEvents();
            kitCollection.Version = 0;

            return kitCollection;
        }
    }
}
