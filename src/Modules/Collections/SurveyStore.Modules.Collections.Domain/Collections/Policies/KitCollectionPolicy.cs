using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public class KitCollectionPolicy : IKitCollectionPolicy
    {
        public (bool, int) IsEnoughKit(IEnumerable<KitCollection> freeKitCollections, string kitType, int requiredAmount)
        {            
            var freeKitTypes = freeKitCollections.Select(k => k.Kit.Type);
            var freeKitAmount = freeKitTypes.Count(t => t == kitType);
            if (freeKitAmount < requiredAmount)
            {
                return (false, freeKitAmount);
            }

            return (true, freeKitAmount);
        }

        public IEnumerable<KitCollection> KitToBeCollected(IEnumerable<KitCollection> freeKitCollections, string kitType,
            StoreId collectionStoreId, int requiredAmount)
        {
            var preferredStoreKit = freeKitCollections
                .Where(k => k.Kit.Type == kitType
                && k.CollectionStoreId == collectionStoreId);

            var kitToBeCollected = new List<KitCollection>();
            foreach (var kit in preferredStoreKit)
            {
                if (requiredAmount > kitToBeCollected.Count)
                {
                    kitToBeCollected.Add(kit);
                }
                else
                {
                    break;
                }
            }

            if (requiredAmount > kitToBeCollected.Count)
            {
                var otherStoresKit = freeKitCollections
                    .Where(k => k.Kit.Type == kitType)
                    .OrderBy(k => k.CollectionStoreId);
                foreach (var kit in otherStoresKit)
                {
                    if (requiredAmount > kitToBeCollected.Count)
                    {
                        kitToBeCollected.Add(kit);
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            
            return kitToBeCollected;

        }
    }
}
