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

        public static Collection Create(Guid id, Guid surveyEquipmentId)
            => new(id, surveyEquipmentId);

        //public void AssignStore(StoreId storeId)
        //{
        //    StoreId = storeId;
        //    AddEvent(new StoreAssigned(storeId));
        //}

        //public void Collect(SurveyorId surveyorId)
        //{
        //    if (StoreId is null)
        //    {
        //        throw new SurveyEquipmentNotFoundInStoreException(SurveyEquipmentId);
        //    }

        //    SurveyorId = surveyorId;
        //    AddEvent(new EquipmentCollected(SurveyEquipmentId, SurveyorId));
        //}
    }
}
