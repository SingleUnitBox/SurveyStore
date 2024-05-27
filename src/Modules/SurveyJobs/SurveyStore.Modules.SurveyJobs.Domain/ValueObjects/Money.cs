using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.ValueObjects
{
    public class Money
    {
        public int Value { get; set; }

        public Money(int value)
        {
            if (value <= 0 || value > 100000)
            {
                throw new InvalidMoneyValueException(value);
            }

            Value = value;
        }
    }
}