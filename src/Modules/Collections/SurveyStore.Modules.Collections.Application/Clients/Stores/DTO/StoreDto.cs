using System;

namespace SurveyStore.Modules.Collections.Application.Clients.Stores.DTO
{
    public class StoreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
