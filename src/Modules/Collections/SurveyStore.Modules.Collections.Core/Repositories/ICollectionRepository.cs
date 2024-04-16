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
        Task DeleteAsync(Collection collection);
        Task<Collection> GetFreeBySurveyEquipmentAsync(SurveyEquipmentId surveyEquipmentId);
        Task<Collection> GetOpenBySurveyEquipmentAsync(SurveyEquipmentId surveyEquipmentId);
        Task<Collection> GetCompletedBySurveyEquipmentAsync(SurveyEquipmentId surveyEquipmentId);
        Task<IEnumerable<Collection>> BrowseCollectionsAsync(SurveyEquipmentId surveyEquipmentId);
    }
}
