using SurveyStore.Modules.Collections.Application.Clients.Surveyors.DTO;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Clients.Surveyors
{
    public interface ISurveyorsApiClient
    {
        Task<SurveyorDto> GetSurveyorAsync(Guid id);
        Task CreateSurveyorAsync(Guid id);
    }
}