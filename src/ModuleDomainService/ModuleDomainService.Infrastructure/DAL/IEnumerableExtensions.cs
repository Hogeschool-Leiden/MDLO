using System.Collections.Generic;
using System.Linq;

namespace ModuleDomainService.Infrastructure.DAL
{
    public static class IEnumerableExtensions
    {
        public static int Version(this IEnumerable<Event> events)
        {
            if (events == null)
            {
                return 0;
            }

            if (events.Count() == 0)
            {
                return 0;
            }

            return events.Max(@event => @event.Stream.Version);
        }
    }
}