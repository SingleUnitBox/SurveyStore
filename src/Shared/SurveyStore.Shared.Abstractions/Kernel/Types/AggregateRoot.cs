using System.Collections.Generic;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; private set; }
        public IEnumerable<IDomainEvent> Events { get; set; }
    }
}
