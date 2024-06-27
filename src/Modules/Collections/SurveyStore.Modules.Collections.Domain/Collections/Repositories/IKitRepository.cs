using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.Repositories
{
    public interface IKitRepository
    {
        Task AddAsync(Kit kit);
        Task UpdateAsync(Kit kit);
        Task UpdateRangeAsync(IEnumerable<Kit> kit);
        Task<Kit> GetByIdAsync(KitId id);
        Task<Kit> GetBySerialNumberAsync(string serialNumber);
    }
}