using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Collection : AggregateRoot
    {
        public Surveyor? Surveyor { get; private set; }
        public StoreId? CollectionStoreId { get; private set; }
        public StoreId?  ReturnStoreId { get; private set; }
        public SurveyEquipmentId SurveyEquipmentId { get; private set; }
        public DateTime? CollectedAt { get; private set; }
        public DateTime? ReturnedAt { get; private set; }

        public Collection(AggregateId id, SurveyEquipmentId surveyEquipmentId)
        {
            Id = id;
            SurveyEquipmentId = surveyEquipmentId;
        }

        public void ChangeCollectionStoreId(StoreId collectionStoreId)
        {
            CollectionStoreId = collectionStoreId;
            IncrementVersion();
        }

        public static Collection Create(Guid id, Guid surveyEquipmentId)
        {
            var collection = new Collection(id, surveyEquipmentId);

            collection.ClearEvents();
            collection.Version = 0;

            return collection;
        }

    }
}
