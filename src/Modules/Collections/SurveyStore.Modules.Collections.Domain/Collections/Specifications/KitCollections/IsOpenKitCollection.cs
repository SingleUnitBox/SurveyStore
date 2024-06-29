using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections
{
    public class IsOpenKitCollection : Specification<KitCollection>
    {
        public override Expression<Func<KitCollection, bool>> AsPredicateExpression()
            => kitCollection => kitCollection.CollectedAt != null
                                && kitCollection.ReturnedAt == null;
    }
}
