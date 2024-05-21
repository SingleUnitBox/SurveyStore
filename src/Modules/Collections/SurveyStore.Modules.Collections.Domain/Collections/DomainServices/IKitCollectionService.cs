using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public interface IKitCollectionService
    {
        (bool isFull, IEnumerable<KitCollection> kitCollection) IsTraverseSetFullForReturn(IEnumerable<KitCollection> openKitCollections);
    }
}