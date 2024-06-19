using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class SurveyEquipment
    {
        public SurveyEquipmentId Id { get; private set; }
        public StoreId StoreId { get; private set; }
        public Store Store { get; private set; }
        public string SerialNumber { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Type { get; private set; }
        public bool IsFree => StoreId is null;

        private SurveyEquipment(SurveyEquipmentId id, string serialNumber, string brand, string model, string type)
        {
            Id = id;
            SerialNumber = serialNumber;
            Brand = brand;
            Model = model;
            Type = type;
        }

        public void AssignStore(StoreId storeId)
        {
            StoreId = storeId;
            //AddEvent(new StoreAssigned(this, storeId));
        }

        public void UnassignStore()
        {
            StoreId = null;
            //IncrementVersion();
        }

        public static SurveyEquipment Create(Guid id, string serialNumber, string brand, string model, string type)
        {
            var equipment = new SurveyEquipment(id, serialNumber, brand, model, type);

            return equipment;
        }
    }
}