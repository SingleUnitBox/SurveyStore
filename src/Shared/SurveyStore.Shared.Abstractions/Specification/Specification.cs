using System;
using System.Linq.Expressions;

namespace SurveyStore.Shared.Abstractions.Specification
{
    public abstract class Specification<T>
    {
        protected abstract Expression<Func<T, bool>> AsPredicateExpression();

        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
            => specification.AsPredicateExpression();
    }
}
