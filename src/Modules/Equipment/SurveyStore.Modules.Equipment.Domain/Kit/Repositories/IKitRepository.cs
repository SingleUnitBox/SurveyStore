using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Repositories
{
    public interface IKitRepository
    {
        Task AddAsync(Entities.Kit kit);
        Task UpdateAsync(Entities.Kit kit);
        Task<Entities.Kit> GetByIdAsync(Guid id);
        Task<Entities.Kit> GetBySerialNumberAsync(string serialNumber);
        Task<IReadOnlyCollection<Entities.Kit>> BrowseAsync();
    }
}
