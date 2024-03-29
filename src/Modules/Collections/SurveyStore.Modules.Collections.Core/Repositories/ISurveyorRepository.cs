using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Repositories
{
    public interface ISurveyorRepository
    {
        Task AddAsync(Surveyor surveyor);
        Task<Surveyor> GetAsync(SurveyorId id);
    }
}
