using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.Repositories
{
    public interface ISurveyorRepository
    {
        Task AddAsync(Surveyor surveyor);
        Task<Surveyor> GetByIdAsync(SurveyorId id);
    }
}
