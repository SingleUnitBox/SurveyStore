using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Core.Repositories
{
    public interface IStoreRepository
    {
        Task<Store> GetByIdAsync(StoreId id);
        Task<Store> GetByNameAsync(string name);
        Task AddAsync(Store store);
        Task UpdateAsync(Store store);
    }
}
