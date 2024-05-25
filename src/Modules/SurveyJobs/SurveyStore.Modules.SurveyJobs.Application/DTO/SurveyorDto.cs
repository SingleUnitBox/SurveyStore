using System;

namespace SurveyStore.Modules.SurveyJobs.Application.DTO
{
    public class SurveyorDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
