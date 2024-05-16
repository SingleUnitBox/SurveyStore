using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public interface ICollectionService
    {
        void CanBeCollected(IEnumerable<Collection> openCollections, Surveyor surveyor,
            Collection toBeCollected, DateTime now);

        IEnumerable<Kit> CollectTraverseSet(IEnumerable<KitCollection> freeKitCollections,
            Surveyor surveyor, Collection toBeCollected, DateTime now);
    }
}
