namespace SurveyStore.Shared.Abstractions.Specification
{
    public static class Extensions
    {
        public static AndSpecification<T> And<T>(this Specification<T> left, Specification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }
    }
}
