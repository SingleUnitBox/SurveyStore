using SurveyStore.Modules.Payments.Application.Clients.SurveyJobs.DTO;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Payments.Application.Clients.SurveyJobs
{
    public interface ISurveyJobsApiClient
    {
        Task<SurveyJobDto> GetSurveyJobAsync(Guid id);
    }
}