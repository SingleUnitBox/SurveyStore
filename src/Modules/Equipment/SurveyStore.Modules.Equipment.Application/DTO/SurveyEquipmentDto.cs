using System;

namespace SurveyStore.Modules.Equipment.Application.DTO
{
    public class SurveyEquipmentDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchasedAt { get; set; }
        public decimal? Accuracy { get; set; }
        public int? MaxRemoteDistance { get; set; }
        public bool? IsActive { get; set; }
        public int? ScreenSize { get; set; }
        public decimal? Frequency { get; set; }
        public bool? OffRoadMode { get; set; }
        public string Type { get; set; }
    }
}
