using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using SurveyStore.Modules.Collections.Core.Exceptions;

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

        public void MakeCollection(Surveyor surveyor)
        {
            if (CollectionStoreId is null)
            {
                throw new SurveyEquipmentNotFoundInStoreException(SurveyEquipmentId);
            }

            Surveyor = surveyor;
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
