using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Repositories
{
    public interface IKitRepository
    {
        Task AddAsync(Entities.Kit kit);
        Task UpdateAsync(Entities.Kit kit);
        Task<Entities.Kit> GetAsyncById(Guid id);
        Task<IReadOnlyCollection<Entities.Kit>> BrowseAsync();
    }
}
