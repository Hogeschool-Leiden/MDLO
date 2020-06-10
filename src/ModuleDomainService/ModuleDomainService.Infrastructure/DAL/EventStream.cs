using System.Collections.Generic;
using System.Linq;
using Miffy.MicroServices.Events;

namespace ModuleDomainService.Infrastructure.DAL
{
    public class EventStream
    {
        private EventStream(string id) =>
            Id = id;

        private EventStream(string id, int version) : this(id) =>
            Version = version;

        public EventStream(string id,
            int version,
            IEnumerable<DomainEvent> events)
            : this(id, version) =>
            Events = events;

        public EventStream(string id, IEnumerable<Event> events) :
            this(id, events.Version()) =>
            Events = events.Select(@event => @event.ToDomainEvent());

        public string Id { get; }
        public int Version { get; private set; }
        public IEnumerable<DomainEvent> Events { get; }

        public IEnumerable<Event> ToEvents =>
            from domainEvent in Events
            select Event.FromDomainEvent(new Stream(Id, ++Version), domainEvent);
    }
}