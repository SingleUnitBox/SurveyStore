using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Types;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public interface IKitCollectionPolicy
    {
        bool IsEnoughKit(IEnumerable<KitCollection> freeKitCollections, string kitType, int requiredAmount);
        IEnumerable<KitCollection> KitToBeCollected(IEnumerable<KitCollection> freeKitCollections, string kitType,
            StoreId collectionStoreId, int requiredAmount);
    }
}
