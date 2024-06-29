using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections
{
    public class IsOpenCollectionById : Specification<Collection>
    {
        private Guid _surveyEquipmentId;
        public IsOpenCollectionById(Guid surveyEquipmentId)
        {
            _surveyEquipmentId = surveyEquipmentId;
        }
        public override Expression<Func<Collection, bool>> AsPredicateExpression()
        {
            return collection => collection.SurveyEquipmentId == _surveyEquipmentId
                                && collection.CollectedAt != null
                                && collection.ReturnStoreId == null;
        }
    }
}
