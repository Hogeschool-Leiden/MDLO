using System.Collections.Generic;
using System.Linq;

namespace ModuleDomainService.Infrastructure.DAL
{
    internal static class IEnumerableExtensions
    {
        internal static int Version(this IEnumerable<Event> events) =>
            events?.Max(@event => @event.Stream.Version) ?? 0;
    }
}