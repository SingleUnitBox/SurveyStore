using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public class AggregateId<T> : IEquatable<AggregateId<T>>
    {
        public T Value { get; }

        public AggregateId(T value)
            => Value = value;
        public bool Equals(AggregateId<T> other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AggregateId<T>)obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
