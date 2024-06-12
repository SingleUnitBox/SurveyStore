using SurveyStore.Modules.Payments.Domain.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Payments.Domain.Repositories
{
    public interface ISurveyJobRepository
    {
        Task AddAsync(SurveyJob surveyJob);
        Task UpdateAsync(SurveyJob surveyJob);
        Task<SurveyJob> GetByIdAsync(AggregateId Id);
    }
}
