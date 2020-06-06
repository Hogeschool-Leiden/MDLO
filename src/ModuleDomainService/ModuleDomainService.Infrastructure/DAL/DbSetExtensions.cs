using Microsoft.EntityFrameworkCore;

namespace ModuleDomainService.Infrastructure.DAL
{
    internal static class DbSetExtensions
    {
        internal static void AppendToStream(this DbSet<Event> dbSet, EventStream eventStream) =>
            dbSet.AddRange(eventStream.ToEvents);
    }
}