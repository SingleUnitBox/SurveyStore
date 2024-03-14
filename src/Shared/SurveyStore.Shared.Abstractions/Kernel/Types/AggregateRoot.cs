using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; private set; }
        public IEnumerable<IDomainEvent> Events => _events;

        private readonly List<IDomainEvent> _events = new();
        private bool _versionIncremented;

        protected void AddEvent(IDomainEvent @event)
        {
            if (!_versionIncremented && _events.Any())
            {
                Version++;
                _versionIncremented = true;
            }

            _events.Add(@event);
        }

        protected void IncrementVersion()
        {
            if (_versionIncremented)
            {
                return;
            }

            Version++;
            _versionIncremented = true;
        }

        public void ClearEvents() => _events.Clear();
    }
}
