using SurveyStore.Modules.Equipment.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Core.Repositories
{
    public interface IStoreRepository
    {
        Task<Store> GetByIdAsync(Guid id);
        Task<Store> GetByNameAsync(string name);
        Task AddAsync(Store store);
        Task UpdateAsync(Store store);
    }
}
