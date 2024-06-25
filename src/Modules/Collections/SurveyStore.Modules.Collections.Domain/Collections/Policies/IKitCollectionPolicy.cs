using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public interface IKitCollectionPolicy
    {
        //(bool, int) IsEnoughKit(IEnumerable<KitCollection> freeKitCollections, string kitType, int requiredAmount);
        //IEnumerable<KitCollection> KitToBeCollected(IEnumerable<KitCollection> freeKitCollections, string kitType,
        //    StoreId collectionStoreId, int requiredAmount);
    }
}
