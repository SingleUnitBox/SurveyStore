using System;

namespace SurveyStore.Modules.Collections.Application.DTO
{
    public class SurveyEquipmentDto
    {
        public Guid Id { get; set; }
        public StoreDto? Store { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}