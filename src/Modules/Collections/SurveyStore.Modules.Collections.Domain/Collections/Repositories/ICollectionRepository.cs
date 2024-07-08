using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Specification;

namespace SurveyStore.Modules.Collections.Domain.Collections.Repositories
{
    public interface ICollectionRepository
    {
        Task AddAsync(Collection collection);
        Task UpdateAsync(Collection collection);
        Task DeleteAsync(Collection collection);
        Task<Collection> GetAsPredicateExpressionAsync(Specification<Collection> specification);
        Task<IEnumerable<Collection>> BrowseCollectionsAsync(SurveyEquipmentId surveyEquipmentId);
        Task<IEnumerable<Collection>> BrowseOpenCollectionsBySurveyorIdAsync(SurveyorId surveyorId);
        Task<IEnumerable<Collection>> BrowseAsPredicateExpressionAsync(Specification<Collection> specification);
    }
}
