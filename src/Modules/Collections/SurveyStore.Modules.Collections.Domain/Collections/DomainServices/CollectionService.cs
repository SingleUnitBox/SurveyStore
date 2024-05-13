﻿using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Modules.Collections.Domain.Collections.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    internal class CollectionService : ICollectionService
    {
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

        public void Collect(IEnumerable<Collection> openCollections, Surveyor surveyor, Collection toBeCollected, DateTime now)
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

            toBeCollected.Collect(surveyor, now);
        }

        public void CollectTraverseSet(IEnumerable<Collection> openCollections, IEnumerable<KitCollection> freeKitCollections,
            Surveyor surveyor, Collection toBeCollected, DateTime now)
        {
            if (_kitCollectionPolicy.CanBeCollected(freeKitCollections, KitTypes.Tripod.ToString(), 3))
            {
                throw new NotEnoughKitAvailableToFormSetException(KitTypes.Tripod);
            }

            if (_kitCollectionPolicy.CanBeCollected(freeKitCollections, KitTypes.TraversePrism.ToString(), 2))
            {
                throw new NotEnoughKitAvailableToFormSetException(KitTypes.TraversePrism);
            }

            var tripods = freeKitCollections
                .Where(k => k.Kit.Type == KitTypes.Tripod
                && k.CollectionStoreId == toBeCollected.CollectionStoreId)
                .Take(3);
            foreach (var tripod in tripods)
            {
                tripod.Collect(surveyor, now);
            }

            var prisms = freeKitCollections
                .Where(k => k.Kit.Type == KitTypes.TraversePrism
                && k.CollectionStoreId == toBeCollected.CollectionStoreId)
                .Take(2);
            foreach (var prism in prisms)
            {
                prism.Collect(surveyor, now);
            }

            toBeCollected.Collect(surveyor, now);
        }
    }
}
