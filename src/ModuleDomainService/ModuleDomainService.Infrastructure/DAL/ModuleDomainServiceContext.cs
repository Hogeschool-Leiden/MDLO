using Microsoft.EntityFrameworkCore;

namespace ModuleDomainService.Infrastructure.DAL
{
    public class ModuleDomainServiceContext : DbContext
    {
        public ModuleDomainServiceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Stream { get; set; }

        public void AppendToStream(EventStream eventStream) => Stream.AppendToStream(eventStream);
    }
}