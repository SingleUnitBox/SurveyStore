using System;
using System.Linq.Expressions;

namespace SurveyStore.Shared.Abstractions.Specification
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> AsPredicateExpression();

        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
            => specification.AsPredicateExpression();

        public static AndSpecification<T> operator &(Specification<T> left, Specification<T> right)
            => left.And(right)
    }
}
