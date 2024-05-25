using SurveyStore.Modules.SurveyJobs.Application.Clients.Surveyors.DTO;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Clients.Surveyors
{
    public interface ISurveyorsApiClient
    {
        Task<SurveyorDto> GetSurveyorAsync(Guid id);
    }
}
