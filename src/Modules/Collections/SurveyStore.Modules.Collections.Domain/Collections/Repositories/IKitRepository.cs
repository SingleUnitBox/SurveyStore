using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.Repositories
{
    public interface IKitRepository
    {
        Task AddAsync(Kit kit);
        Task UpdateAsync(Kit kit);
        Task<Kit> GetAsync(AggregateId id);
        Task<Kit> GetBySerialNumberAsync(string serialNumber);
    }
}