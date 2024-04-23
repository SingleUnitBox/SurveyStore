using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Core.DomainServices
{
    internal class CollectionService : ICollectionService
    {
        public void Collect(IEnumerable<Collection> allCollections, SurveyorId surveyorId, Collection toBeCollected)
        {
            throw new System.NotImplementedException();
        }
    }
}
 