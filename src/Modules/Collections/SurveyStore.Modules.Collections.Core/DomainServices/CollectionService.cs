using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.Collections.Core.DomainServices
{
    internal class CollectionService : ICollectionService
    {
        private readonly string[] limitedSurveyEquipmentTypes = new[]
            {
                "total station",
                "gnss"
            };

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
    }
}
 