using SurveyStore.Modules.Collections.Domain.Collections.DomainEvents;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class Collection : AggregateRoot
    {
        public SurveyEquipment SurveyEquipment { get; private set; }
        public SurveyEquipmentId SurveyEquipmentId { get; private set; }
        public Surveyor Surveyor { get; private set; }
        public StoreId CollectionStoreId { get; private set; }
        public StoreId ReturnStoreId { get; private set; }
        public Date CollectedAt { get; private set; }
        public Date ReturnedAt { get; private set; }

        private Collection(AggregateId id, SurveyEquipmentId surveyEquipmentId)
        {
            Id = id;
            SurveyEquipmentId = surveyEquipmentId;
        }

        public void AssignStore(StoreId collectionStoreId)
        {
            if (CollectionStoreId == collectionStoreId)
            {
                return;
            }
            CollectionStoreId = collectionStoreId;
            IncrementVersion();
        }

        internal void Collect(Surveyor surveyor, DateTime collectedAt)
        {
            if (CollectionStoreId is null)
            {
                throw new SurveyEquipmentNotFoundInStoreException(SurveyEquipmentId);
            }

            Surveyor = surveyor;
            CollectedAt = collectedAt;
            AddEvent(new CollectionCollected(SurveyEquipmentId, CollectionStoreId));
        }

        public void Return(StoreId returnStoreId, DateTime returnAt)
        {
            ReturnStoreId = returnStoreId;
            ReturnedAt = returnAt;
            AddEvent(new CollectionReturned(SurveyEquipmentId, ReturnStoreId?.Value));
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
