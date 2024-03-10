using System;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public abstract class SurveyEquipment
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchasedAt { get; set; }
        public DateTime? CalibrationDate { get; set; }
        public TimeSpan? CalibrationInterval { get; set; }
        public Store? Store { get; set; }

    }
}
