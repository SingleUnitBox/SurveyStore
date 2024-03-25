using System;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;

namespace SurveyStore.Modules.Collections.Core.Repositories
{
    public interface IStoreRepository
    {
        Task<Store> GetByIdAsync(Guid id);
        Task<Store> GetByNameAsync(string name);
        Task AddAsync(Store store);
        Task UpdateAsync(Store store);
    }
}
