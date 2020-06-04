using Microsoft.EntityFrameworkCore;

namespace ModuleDomainService.Infrastructure.DAL
{
    public class ModuleDomainServiceContext : DbContext
    {
        public ModuleDomainServiceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}