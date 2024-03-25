using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;

namespace SurveyStore.Modules.Collections.Core.Repositories
{
    public interface ISurveyorRepository
    {
        Task AddAsync(Surveyor surveyor);
    }
}
