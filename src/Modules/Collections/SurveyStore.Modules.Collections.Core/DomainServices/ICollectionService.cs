using SurveyStore.Modules.Collections.Core.Entities;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Core.DomainServices
{
    internal interface ICollectionService
    {
        void Collect(IEnumerable<Collection> openCollections, Surveyor surveyor,
            Collection toBeCollected, DateTime now);
    }
}
 