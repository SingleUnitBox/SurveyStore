using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications
{
    public class IsOpenCollection : Specification<Collection>
    {
        private Guid _surveyEquipmentId;
        public IsOpenCollection(Guid surveyEquipmentId)
        {
            _surveyEquipmentId = surveyEquipmentId;
        }
        protected override Expression<Func<Collection, bool>> AsPredicateExpression()
        {
            return collection => collection.SurveyEquipmentId == _surveyEquipmentId
                                && collection.CollectedAt != null
                                && collection.ReturnStoreId == null;
        }
    }
}
