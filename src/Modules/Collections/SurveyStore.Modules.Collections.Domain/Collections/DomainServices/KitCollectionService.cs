using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public class KitCollectionService : IKitCollectionService
    {
        private readonly KitConstOptions _kitOptions;
        private readonly IKitCollectionRepository _kitCollectionRepository;

        public KitCollectionService(KitConstOptions kitOptions,
            IKitCollectionRepository kitCollectionRepository)
        {
            _kitOptions = kitOptions;
            _kitCollectionRepository = kitCollectionRepository;
        }
        public async Task<IEnumerable<KitCollection>> GatherTraverseSet(IEnumerable<KitCollection> openKitCollections)
        {
            var kitToBeCollected = new List<KitCollection>();
            var freeKitCollections = await _kitCollectionRepository
                .BrowseAsPredicateExpression(new IsFreeKitCollection());

            var tripodsToBeCollected = GatherRequiredKit(openKitCollections, freeKitCollections,
                KitTypes.Tripod, _kitOptions.TripodRequiredAmount);
            kitToBeCollected.AddRange(tripodsToBeCollected);

            var prismsToBeCollected = GatherRequiredKit(openKitCollections, freeKitCollections,
                KitTypes.TraversePrism, _kitOptions.PrismRequiredAmount);
            kitToBeCollected.AddRange(prismsToBeCollected);

            return kitToBeCollected;
        }

        private IEnumerable<KitCollection> GatherRequiredKit(IEnumerable<KitCollection> openKitCollections,
            IEnumerable<KitCollection> freeKitCollections, string kitType, int kitRequiredAmount)
        {
            var kitToBeCollected = new List<KitCollection>();
            var openKitAmount = openKitCollections
                .Where(k => k.Kit.Type == kitType)
                .Count();

            if (openKitAmount < kitRequiredAmount)
            {
                var freeKit = freeKitCollections.Where(k => k.Kit.Type == kitType);
                var availableKitAmount = openKitAmount + freeKit.Count();
                if (availableKitAmount < kitRequiredAmount)
                {
                    throw new NotEnoughKitAvailableToFormSetException(
                        kitType, kitRequiredAmount, availableKitAmount);
                }

                foreach (var kit in freeKit)
                {
                    if (kitToBeCollected.Count() + openKitAmount < kitRequiredAmount)
                    {
                        kitToBeCollected.Add(kit);
                        _kitCollectionRepository.Detach(kit);
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
