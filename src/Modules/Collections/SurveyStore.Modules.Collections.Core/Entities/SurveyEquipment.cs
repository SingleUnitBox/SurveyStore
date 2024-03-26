using System;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class SurveyEquipment
    {
        public SurveyEquipmentId Id { get; set; }
        public StoreId? StoreId { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public SurveyEquipment(SurveyEquipmentId id, string serialNumber, string brand, string model)
        {
            Id = id;
            SerialNumber = serialNumber;
            Brand = brand;
            Model = model;
        }

        public static SurveyEquipment Create(Guid id, string serialNumber, string brand, string model)
            => new(id, serialNumber, brand, model);

        public void AssignStore(StoreId storeId)
        {
            StoreId = storeId;
        }
    }
}
