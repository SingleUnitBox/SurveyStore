using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public interface IKitCollectionService
    {
        (bool, IEnumerable<KitCollection>) IsTraverseSetFullForReturn(IEnumerable<KitCollection> openKitCollections);
    }
}