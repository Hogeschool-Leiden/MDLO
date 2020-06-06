using System.Collections.Generic;
using System.Linq;
using Miffy.MicroServices.Events;

namespace ModuleDomainService.Domain.Abstractions
{
    public abstract class AggregateRoot
    {
        protected AggregateRoot() => Changes = new List<DomainEvent>();

        protected AggregateRoot(IEnumerable<DomainEvent> events) : this() => Rewind(events.ToList());

        public abstract string Id { get; }
        public int Version { get; private set; }
        public List<DomainEvent> Changes { get; }

        protected void Apply(DomainEvent @event)
        {
            Changes.Add(@event);
            Mutate(@event);
        }

        protected abstract void Mutate(DomainEvent @event);

        private void Rewind(List<DomainEvent> events)
        {
            events.ForEach(@event =>
            {
                Mutate(@event);
                Version++;
            });
        }
    }
}