using System;

namespace SurveyStore.Modules.Collections.Application.Clients.Equipment.Kit.DTO
{
    public class KitDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
    }
}
