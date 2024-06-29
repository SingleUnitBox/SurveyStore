using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections
{
    public class IsOpenCollection : Specification<Collection>
    {
        public override Expression<Func<Collection, bool>> AsPredicateExpression()
            => collection => collection.CollectedAt != null
                            && collection.ReturnedAt == null;
    }
}
