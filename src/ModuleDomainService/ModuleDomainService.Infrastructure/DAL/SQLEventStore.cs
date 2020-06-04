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

            return ToEventStream(streamId, events);
        }

        public void AppendToStream(EventStream eventStream)
        {
            // TODO: Refactor
            var events = eventStream.Events.Select(domainEvent =>
                SerializeEvent(eventStream.Id, eventStream.Version, domainEvent));
            _context.Events.AddRange(events);
            _context.SaveChanges();
        }

        private static Event SerializeEvent(string streamId, int version, DomainEvent domainEvent)
        {
            return new Event
            {
                Id = $"{streamId}:{++version}:{nameof(ModuleGecreeerd)}",
                Stream = new Stream
                {
                    Id = streamId,
                    Version = version
                },
                Type = domainEvent.Type,
                Payload = JsonConvert.SerializeObject(domainEvent)
            };
        }

        private static EventStream ToEventStream(string streamId, IReadOnlyCollection<Event> events)
        {
            var version = events.Max(@event => @event.Stream.Version);

            var domainEvents = events.Select(@event => JsonConvert.DeserializeObject<DomainEvent>(@event.Payload));

            return new EventStream(streamId, version, domainEvents);
        }
    }
}