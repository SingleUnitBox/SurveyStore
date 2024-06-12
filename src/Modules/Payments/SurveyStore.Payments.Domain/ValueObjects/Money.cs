namespace SurveyStore.Modules.Payments.Domain.ValueObjects
{
    public class Money
    {
        public int Value { get; private set; }

        public Money(int value)
        {
            Value = value;
        }

        public static implicit operator Money(int value) => new Money(value);
        public static implicit operator int(Money value) => value.Value;
    }
}
