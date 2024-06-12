using System;

namespace SurveyStore.Modules.Payments.Application.Clients.SurveyJobs.DTO
{
    public class SurveyJobDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime IssuedAt { get; set; }
        public int Budget { get; set; }
        public int CostToDeliver { get; set; }
    }
}
