using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class KitCollection : AggregateRoot
    {
        public Surveyor Surveyor { get; private set; }
        public StoreId CollectionStoreId { get; private set; }
        public StoreId ReturnStoreId { get; private set; }
        public Kit Kit { get; private set; }
        public AggregateId KitId { get; private set; }
        public DateTime? CollectedAt { get; private set; }
        public DateTime? ReturnedAt { get; private set; }

        internal KitCollection(AggregateId id, AggregateId kitId)
        {
            Id = id;
            KitId = kitId;
        }

        public void ChangeCollectionStore(StoreId storeId)
        {
            CollectionStoreId = storeId;
            IncrementVersion();
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
    }
}
