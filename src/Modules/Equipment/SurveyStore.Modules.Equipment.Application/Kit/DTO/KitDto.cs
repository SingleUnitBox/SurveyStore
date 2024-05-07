using System;

namespace SurveyStore.Modules.Equipment.Application.Kit.DTO
{
    public class KitDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchasedAt { get; set; }
        public string Type { get; set; }
    }
}
