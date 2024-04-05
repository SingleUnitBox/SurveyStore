using System;
using SurveyStore.Modules.Collections.Core.DomainEvents;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class SurveyEquipment : AggregateRoot
    {
        public StoreId? StoreId { get; private set; }
        public Store? Store { get; private set; }
        public string SerialNumber { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }

        public SurveyEquipment(AggregateId id, string serialNumber, string brand, string model)
        {
            Id = id;
            SerialNumber = serialNumber;
            Brand = brand;
            Model = model;
        }

        public static SurveyEquipment Create(Guid id, string serialNumber, string brand, string model)
        {
            var equipment = new SurveyEquipment(id, serialNumber, brand, model);

            equipment.ClearEvents();
            equipment.Version = 0;

            return equipment;
        }

        public void AssignStore(StoreId storeId)
        {
            StoreId = storeId;
            AddEvent(new StoreAssigned(this, storeId));
        }
    }
}
