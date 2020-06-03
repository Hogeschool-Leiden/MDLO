using System.Collections.Generic;
using System.Linq;
using Miffy.MicroServices.Events;
using ModuleDomainService.Domain.Events;
using Newtonsoft.Json;

namespace ModuleDomainService.Infrastructure.DAL
{
    public class SQLEventStore : IEventStore
    {
        private readonly ModuleDomainServiceContext _context;

        public SQLEventStore(ModuleDomainServiceContext context) => _context = context;

        public EventStream LoadStream(string streamId)
        {
            var events = _context
                .Events
                .Where(@event => @event.Stream.Id.Equals(streamId))
                .OrderBy(@event => @event.Stream.Version)
                .ToList();
            var version = events.Max(@event => @event.Stream.Version);
            var domainEvents = events.Select(@event => JsonConvert.DeserializeObject<DomainEvent>(@event.Payload));
            return new EventStream(streamId, version, domainEvents);
        }

        public void AppendToStream(string streamId, int version, IEnumerable<DomainEvent> events)
        {
            _context.Events.AddRange(events.Select(@event => new Event
            {
                Id = $"{streamId}:{++version}:{nameof(ModuleGecreeerd)}",
                Stream = new Stream
                {
                    Id = streamId,
                    Version = version
                },
                Type = @event.Type,
                Payload = JsonConvert.SerializeObject(@event)
            }));
            _context.SaveChanges();
        }
    }
}