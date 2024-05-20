using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.Repositories
{
    public interface IKitCollectionRepository
    {
        Task AddAsync(KitCollection kitCollection);
        Task UpdateAsync(KitCollection kitCollection);
        Task UpdateRangeAsync(IEnumerable<KitCollection> kitCollections);
        Task<KitCollection> GetFreeByKitAsync(AggregateId kitId);
        Task<KitCollection> GetOpenByKitAsync(AggregateId kitId);
        Task<IEnumerable<KitCollection>> BrowseOpenKitCollectionsBySurveyorAsync(SurveyorId surveyorId);
        Task<IEnumerable<KitCollection>> BrowseFreeKitCollectionsAsync();
        Task<IEnumerable<KitCollection>> BrowseKitCollectionsAsync(AggregateId kitId);
    }
}
