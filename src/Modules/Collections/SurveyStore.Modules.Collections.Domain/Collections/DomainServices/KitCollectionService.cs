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

        public async Task<IEnumerable<KitCollection>> GatherTraverseSet(IEnumerable<KitCollection> openSurveyorKitCollections)
        {
            var kitToBeCollected = new List<KitCollection>();
            var freeKitCollections = await _kitCollectionRepository
                .BrowseAsPredicateExpression(new IsFreeKitCollection());

            var tripodsToBeCollected = GatherRequiredKit(openSurveyorKitCollections, freeKitCollections,
                KitTypes.Tripod, _kitOptions.TripodRequiredAmount);
            kitToBeCollected.AddRange(tripodsToBeCollected);

            var prismsToBeCollected = GatherRequiredKit(openSurveyorKitCollections, freeKitCollections,
                KitTypes.TraversePrism, _kitOptions.PrismRequiredAmount);
            kitToBeCollected.AddRange(prismsToBeCollected);

            return kitToBeCollected;
        }

        public IEnumerable<KitCollection> GatherTraverseSetForReturn(IEnumerable<KitCollection> openSurveyorKitCollections)
        {
            var kitToBeReturned = new List<KitCollection>();

            var tripodsToBeReturned = CheckKitForReturn(openSurveyorKitCollections, KitTypes.Tripod, _kitOptions.TripodRequiredAmount);
            kitToBeReturned.AddRange(tripodsToBeReturned);

            var prismsToBeReturned = CheckKitForReturn(openSurveyorKitCollections, KitTypes.TraversePrism, _kitOptions.PrismRequiredAmount);
            kitToBeReturned.AddRange(prismsToBeReturned);

            return kitToBeReturned;
        }

        private IEnumerable<KitCollection> GatherRequiredKit(IEnumerable<KitCollection> openSurveyorKitCollections,
            IEnumerable<KitCollection> freeKitCollections, string kitType, int kitRequiredAmount)
        {
            var kitToBeCollected = new List<KitCollection>();
            var openSurveyorKitAmount = openSurveyorKitCollections
                .Where(k => k.Kit.Type == kitType)
                .Count();

            if (openSurveyorKitAmount < kitRequiredAmount)
            {
                var freeKit = freeKitCollections.Where(k => k.Kit.Type == kitType);
                var availableKitAmount = openSurveyorKitAmount + freeKit.Count();
                if (availableKitAmount < kitRequiredAmount)
                {
                    throw new NotEnoughKitAvailableToFormSetException(
                        kitType, kitRequiredAmount, availableKitAmount);
                }

                foreach (var kit in freeKit)
                {
                    if (kitToBeCollected.Count() + openSurveyorKitAmount < kitRequiredAmount)
                    {
                        kitToBeCollected.Add(kit);
                        //_kitCollectionRepository.Detach(kit);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return kitToBeCollected;
        }

        private IEnumerable<KitCollection> CheckKitForReturn(IEnumerable<KitCollection> openKitCollections,
            string kitType, int kitRequiredAmount)
        {
            var kitToBeReturned = new List<KitCollection>();
            var availableKit = openKitCollections
                .Where(k => k.Kit.Type == kitType);

            if (openKitCollections.Count() < kitRequiredAmount)
            {
                throw new NotEnoughKitAvailableToFormSetException(
                        kitType, kitRequiredAmount, availableKit.Count());
            }

            foreach (var kit in availableKit)
            {
                if (kitToBeReturned.Count() < kitRequiredAmount)
                {
                    kitToBeReturned.Add(kit);
                    //_kitCollectionRepository.Detach(kit);
                }
                else
                {
                    break;
                }
            }

            return kitToBeReturned;
        }
    }
}
