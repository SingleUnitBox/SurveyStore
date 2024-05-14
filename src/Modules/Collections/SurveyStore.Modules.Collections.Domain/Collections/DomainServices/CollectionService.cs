using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    internal class CollectionService : ICollectionService
    {
        private readonly int _tripodRequiredAmount = 3;
        private readonly int _prismRequiredAmount = 2;

        private readonly string[] limitedSurveyEquipmentTypes = new[]
            {
                "total station",
                "gnss"
            };

        private readonly IKitCollectionPolicy _kitCollectionPolicy;

        public CollectionService(IKitCollectionPolicy kitCollectionPolicy)
        {
            _kitCollectionPolicy = kitCollectionPolicy;
        }

        public void CanBeCollected(IEnumerable<Collection> openCollections, Surveyor surveyor, Collection toBeCollected, DateTime now)
        {
            var surveyEquipmentTypes = openCollections.Select(c => c.SurveyEquipment.Type);
            foreach (var surveyEquipmentType in surveyEquipmentTypes)
            {
                if (limitedSurveyEquipmentTypes.Contains(surveyEquipmentType)
                    && toBeCollected.SurveyEquipment.Type == surveyEquipmentType)
                {
                    throw new CannotCollectSurveyEquipmentException(surveyEquipmentType);
                }
            }

            //toBeCollected.Collect(surveyor, now);
        }

        public void CollectTraverseSet(IEnumerable<KitCollection> freeKitCollections,
            Surveyor surveyor, Collection toBeCollected, DateTime now)
        {
            var (isEnough, actualAmount) = _kitCollectionPolicy
                .IsEnoughKit(freeKitCollections, KitTypes.Tripod.ToString(), _tripodRequiredAmount);
            if (!isEnough)
            {
                throw new NotEnoughKitAvailableToFormSetException(KitTypes.Tripod, _tripodRequiredAmount, actualAmount);
            }

            (isEnough, actualAmount) = _kitCollectionPolicy
                .IsEnoughKit(freeKitCollections, KitTypes.TraversePrism.ToString(), _prismRequiredAmount);
            if (!isEnough)
            {
                throw new NotEnoughKitAvailableToFormSetException(KitTypes.TraversePrism, _prismRequiredAmount, actualAmount);
            }

            var collectionStoreId = toBeCollected.CollectionStoreId;
            var tripods = _kitCollectionPolicy.KitToBeCollected(freeKitCollections, KitTypes.Tripod.ToString(),
                collectionStoreId, _tripodRequiredAmount);
            foreach (var tripod in tripods)
            {
                tripod.Collect(surveyor, now);
            }

            var prisms = _kitCollectionPolicy.KitToBeCollected(freeKitCollections, KitTypes.TraversePrism.ToString(),
                collectionStoreId, _prismRequiredAmount);
            foreach (var prism in prisms)
            {
                prism.Collect(surveyor, now);
            }

            toBeCollected.Collect(surveyor, now);
        }
    }
}
