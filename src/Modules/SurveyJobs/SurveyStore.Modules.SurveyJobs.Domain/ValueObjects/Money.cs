using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;
using System.Runtime.InteropServices;

namespace SurveyStore.Modules.SurveyJobs.Domain.ValueObjects
{
    public class Money
    {
        public int Value { get; set; }

        private Money()
        {
            
        }

        public void ChangeValue(int value)
        {
            if (value <= 0 || value > 100000)
            {
                throw new InvalidMoneyValueException(value);
            }

            Value = value;
        }

        public static Money Create(int value)
        {
            var money = new Money();
            money.ChangeValue(value);

            return money;
        }
    }
}