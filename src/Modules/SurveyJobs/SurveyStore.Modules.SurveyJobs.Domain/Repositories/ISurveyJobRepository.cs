using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Domain.Repositories
{
    public interface ISurveyJobRepository
    {
        Task AddAsync(SurveyJob surveyJob);
        Task UpdateAsync(SurveyJob surveyJob);
        Task<SurveyJob> GetByIdAsync(AggregateId id);
        Task<IEnumerable<SurveyJob>> BrowseAsync();
        Task<IReadOnlyCollection<SurveyJob>> BrowseForSurveyorAsync(Guid surveyorId);
    }
}
