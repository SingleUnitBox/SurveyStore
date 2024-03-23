using System;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class SurveyEquipment
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
