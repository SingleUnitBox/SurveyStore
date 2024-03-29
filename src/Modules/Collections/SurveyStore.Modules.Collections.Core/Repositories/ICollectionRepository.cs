using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Repositories
{
    public interface ICollectionRepository
    {
        Task AddAsync(Collection collection);
        Task UpdateAsync(Collection collection);
        Task<Collection> GetCurrentBySurveyEquipmentAsync(SurveyEquipmentId surveyEquipmentId);
        Task<IEnumerable<Collection>> BrowseCollectionsAsync(SurveyEquipmentId surveyEquipmentId);
    }
}
