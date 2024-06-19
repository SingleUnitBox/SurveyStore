using SurveyStore.Modules.Collections.Domain.Collections.DomainEvents;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class Collection : AggregateRoot
    {
        public Surveyor Surveyor { get; private set; }
        public StoreId CollectionStoreId { get; private set; }
        public StoreId ReturnStoreId { get; private set; }
        //public SurveyEquipment SurveyEquipment { get; private set; }
        public SurveyEquipmentId SurveyEquipmentId { get; private set; }
        public DateTime? CollectedAt { get; private set; }
        public DateTime? ReturnedAt { get; private set; }

        private Collection(AggregateId id, SurveyEquipmentId surveyEquipmentId)
        {
            Id = id;
            SurveyEquipmentId = surveyEquipmentId;
        }

        public void ChangeCollectionStoreId(StoreId collectionStoreId)
        {
            CollectionStoreId = collectionStoreId;
            //SurveyEquipment.AssignStore(collectionStoreId);
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
            //SurveyEquipment.UnassignStore();
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
