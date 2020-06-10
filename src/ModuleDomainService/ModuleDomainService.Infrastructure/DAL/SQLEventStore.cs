using System.Collections.Generic;
using System.Linq;

namespace ModuleDomainService.Infrastructure.DAL
{
    public class SQLEventStore : IEventStore
    {
        private readonly ModuleDomainServiceContext _context;

        public SQLEventStore(ModuleDomainServiceContext context) => _context = context;

        public EventStream LoadStream(string streamId) =>
            new EventStream(streamId, LoadEvents(streamId));

        public void AppendToStream(EventStream eventStream)
        {
            _context.AppendToStream(eventStream);
            _context.SaveChanges();
        }

        private IEnumerable<Event> LoadEvents(string streamId) =>
            _context
                .Stream
                .Where(@event => @event.Stream.Id.Equals(streamId))
                .OrderBy(@event => @event.Stream.Version)
                .ToList();
    }
}