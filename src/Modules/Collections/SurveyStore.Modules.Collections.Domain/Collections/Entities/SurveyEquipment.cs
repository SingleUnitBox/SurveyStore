using SurveyStore.Modules.Collections.Domain.Collections.DomainEvents;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class SurveyEquipment : AggregateRoot
    {
        public StoreId StoreId { get; private set; }
        public Store Store { get; private set; }
        public string SerialNumber { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Type { get; private set; }
        public bool IsFree => StoreId is null;

        public SurveyEquipment(AggregateId id, string serialNumber, string brand, string model, string type)
        {
            Id = id;
            SerialNumber = serialNumber;
            Brand = brand;
            Model = model;
            Type = type;
        }

        public static SurveyEquipment Create(Guid id, string serialNumber, string brand, string model, string type)
        {
            var equipment = new SurveyEquipment(id, serialNumber, brand, model, type);

            equipment.ClearEvents();
            equipment.Version = 0;

            return equipment;
        }

        public void AssignStore(StoreId storeId)
        {
            StoreId = storeId;
            AddEvent(new StoreAssigned(this, storeId));
        }

        public void UnassignStore()
        {
            StoreId = null;
            IncrementVersion();
        }
    }
}
