using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;

namespace SurveyStore.Modules.Collections.Core.Repositories
{
    public interface ICollectionRepository
    {
        Task AddAsync(Collection collection);
        Task UpdateAsync(Collection collection);
    }
}
