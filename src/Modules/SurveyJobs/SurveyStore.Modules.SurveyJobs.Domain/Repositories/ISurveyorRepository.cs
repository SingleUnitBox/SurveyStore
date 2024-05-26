using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Domain.Repositories
{
    public interface ISurveyorRepository
    {
        Task AddAsync(Surveyor surveyor);
        Task UpdateAsync(Surveyor surveyor);
        Task<Surveyor> GetByIdAsync(AggregateId id);
        Task<Surveyor> GetByEmailAsync(string email);
        Task<IReadOnlyCollection<Surveyor>> BrowseAsync();
    }
}
