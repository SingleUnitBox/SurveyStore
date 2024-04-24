 using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using SurveyStore.Modules.Collections.Core.DomainEvents;
using SurveyStore.Modules.Collections.Core.Exceptions;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Collection : AggregateRoot
    {
        public Surveyor? Surveyor { get; private set; }
        public StoreId? CollectionStoreId { get; private set; }
        public StoreId? ReturnStoreId { get; private set; }
        public SurveyEquipment SurveyEquipment { get; private set; }
        public AggregateId SurveyEquipmentId { get; private set; }
        public DateTime? CollectedAt { get; private set; }
        public DateTime? ReturnedAt { get; private set; }

        public Collection(AggregateId id, AggregateId surveyEquipmentId)
        {
            Id = id;
            SurveyEquipmentId = surveyEquipmentId;
        }

        public void ChangeCollectionStoreId(StoreId collectionStoreId)
        {
            CollectionStoreId = collectionStoreId;
            IncrementVersion();
        }

        public void Collect(Surveyor surveyor, DateTime collectedAt)
        {
            if (CollectionStoreId is null)
            {
                throw new SurveyEquipmentNotFoundInStoreException(SurveyEquipmentId);
            }

            Surveyor = surveyor;
            CollectedAt = collectedAt;
            IncrementVersion();
        }

        public void Return(StoreId returnStoreId, DateTime returnAt)
        {
            ReturnStoreId = returnStoreId;
            ReturnedAt = returnAt;
            AddEvent(new ReturnStoreAssigned(ReturnStoreId?.Value));
            IncrementVersion();
        }

        public void ReturnForCalibration(StoreId returnStoreId, DateTime returnAt)
        {
            ReturnStoreId = returnStoreId;
            ReturnedAt = returnAt;
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
