using System;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class SurveyEquipment
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public static SurveyEquipment Create(Guid id, string serialNumber, string brand, string model)
            => new SurveyEquipment()
            {
                Id = id,
                SerialNumber = serialNumber,
                Brand = brand,
                Model = model
            };
    }
}
