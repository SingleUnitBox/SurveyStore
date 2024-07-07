using System;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public class Date
    {
        public DateTime Value { get; private set; }
        public Date(DateTime value)
        {
            Value = value;
        }

        public static implicit operator Date(DateTime value) => new(value);
        public static implicit operator DateTime(Date date) => date.Value;
        public static bool operator ==(Date date1, Date date2)
        {
            if (ReferenceEquals(date1, null) && ReferenceEquals(date2, null))
            {
                return true;
            }

            if (ReferenceEquals(date1, null) || ReferenceEquals(date2, null))
            {
                return false;
            }

            return date1.Value == date2.Value;
        }
        public static bool operator !=(Date date1, Date date2) => !(date1 == date2);
        public static bool operator <(Date date1, Date date2) => date1?.Value < date2?.Value;
        public static bool operator >(Date date1, Date date2) => date1?.Value > date2?.Value;
        public static bool operator <=(Date date1, Date date2) => date1?.Value <= date2?.Value;
        public static bool operator >=(Date date1, Date date2) => date1?.Value >= date2?.Value;

        public override bool Equals(object obj)
        {
            if (obj is Date otherDate)
            {
                return Value == otherDate.Value;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
