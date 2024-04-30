using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.Repositories
{
    public interface IStoreRepository
    {
        Task<Store> GetByIdAsync(StoreId id);
        Task<Store> GetByNameAsync(string name);
        Task AddAsync(Store store);
        Task UpdateAsync(Store store);
    }
}
