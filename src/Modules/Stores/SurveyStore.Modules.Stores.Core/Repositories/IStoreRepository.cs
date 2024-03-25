using SurveyStore.Modules.Stores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.Repositories
{
    public interface IStoreRepository
    {
        Task AddAsync(Store store);
        Task UpdateAsync(Store store);
        Task DeleteAsync(Store store);
        Task<Store> GetAsync(Guid id);
        Task<Store> GetByNameAsync(string name);
        Task<IReadOnlyList<Store>> BrowseAsync();
    }
}
