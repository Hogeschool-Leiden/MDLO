using Microsoft.EntityFrameworkCore;
using ModuleFrontend.Api.Models;

namespace ModuleFrontend.Api.DAL
{
    public class ModuleContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Specialisatie> Specialisaties { get; set; }
        public ModuleContext(DbContextOptions<ModuleContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>()
                .HasIndex(module => module.ModuleCode)
                .IsUnique();
        }
    }
}
