using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public interface IKitCollectionService
    {
        Task<IEnumerable<KitCollection>> GatherTraverseSet(IEnumerable<KitCollection> openKitCollections,
            Surveyor surveyor, Date collectedAt);
    }
}