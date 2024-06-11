using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using System.Linq;

namespace SurveyStore.Modules.SurveyJobs.Application.Mappings
{
    public static class Extensions
    {
        public static SurveyJobDto AsDto(this SurveyJob surveyJob)
        {
            var surveyJobDto = new SurveyJobDto()
            {
                Id = surveyJob.Id,
                Name = surveyJob.Name.Name,
                BriefIssued = surveyJob.BriefIssued,
                DueDate = surveyJob.DueDate,
                SurveyType = surveyJob.SurveyType.Value,
                Budget = surveyJob.Budget.Value,
            };

            if (surveyJob.Surveyors is not null)
            {
                surveyJobDto.Surveyors = surveyJob.Surveyors
                    .Select(s => new SurveyorDto()
                    {
                        Id = s?.Id,
                        FirstName = s?.FirstName,
                        Surname = s?.Surname,
                        Email = s?.Email,
                    }
                    );
            }

            if (surveyJob.Documents is not null)
            {
                surveyJobDto.Documents = surveyJob.Documents
                    .Select(d => new DocumentDto()
                    {
                        DocumentType = d.DocumentType.Name,
                        Link = d.Link,
                    });
            }

            return surveyJobDto;
        }
    }
}
