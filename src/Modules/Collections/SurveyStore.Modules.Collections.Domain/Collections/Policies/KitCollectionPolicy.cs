using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public class KitCollectionPolicy : IKitCollectionPolicy
    {
        //private readonly IKitRepository _kitRepository;

        //public KitCollectionPolicy(IKitRepository kitRepository)
        //{
        //    _kitRepository = kitRepository;
        //}

        //public (bool, int) IsEnoughKit(IEnumerable<KitCollection> freeKitCollections, string kitType, int requiredAmount)
        //{            
        //    var tasks = freeKitCollections.Select(async k => await _kitRepository.GetByIdAsync(k.KitId.Value));
        //    var freeKitTypes = Task.WhenAll(tasks).Result.Select(k => k.Type);
        //    var freeKitAmount = freeKitTypes.Count(t => t == kitType);
        //    if (freeKitAmount < requiredAmount)
        //    {
        //        return (false, freeKitAmount);
        //    }

        //    return (true, freeKitAmount);
        //}

        //public IEnumerable<KitCollection> KitToBeCollected(IEnumerable<KitCollection> freeKitCollections, string kitType,
        //    StoreId collectionStoreId, int requiredAmount)
        //{
        //    var preferredStoreKit = Task.WhenAll(freeKitCollections
        //        .Select(async k => await _kitRepository.GetByIdAsync(k.KitId.Value)))
        //        .Result
        //        .Where(k => k.Type == kitType
        //        && k.CollectionStoreId == collectionStoreId)
        //        .ToList();

        //    var kitToBeCollected = new List<KitCollection>();
        //    foreach (var kit in preferredStoreKit)
        //    {
        //        if (requiredAmount > kitToBeCollected.Count)
        //        {
        //            kitToBeCollected.Add(kit);
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    if (requiredAmount > kitToBeCollected.Count)
        //    {
        //        var otherStoresKit = freeKitCollections
        //            .Where(k => k.Kit.Type == kitType
        //            && k.CollectionStoreId != collectionStoreId)
        //            .OrderBy(k => k.CollectionStoreId.Value)
        //            .ToList();
        //        foreach (var kit in otherStoresKit)
        //        {
        //            if (requiredAmount > kitToBeCollected.Count)
        //            {
        //                kitToBeCollected.Add(kit);
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
                
        //    }
            
        //    return kitToBeCollected;
        //}
    }
}
