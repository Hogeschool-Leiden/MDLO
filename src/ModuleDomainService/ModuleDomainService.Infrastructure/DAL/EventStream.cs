using System.Collections.Generic;
using System.Linq;
using Miffy.MicroServices.Events;

namespace ModuleDomainService.Infrastructure.DAL
{
    public class EventStream
    {
        private readonly List<DomainEvent> _events;

        private EventStream(string id) => Id = id;

        private EventStream(string id, int version) : this(id) => Version = version;

        public EventStream(string id,
            int version,
            IEnumerable<DomainEvent> events)
            : this(id, version) =>
            _events = events.ToList();

        public string Id { get; }

        public int Version { get; }

        public IEnumerable<DomainEvent> Events => _events;
    }
}