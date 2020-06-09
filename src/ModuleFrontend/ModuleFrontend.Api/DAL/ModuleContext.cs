using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ModuleFrontend.Api.Models;

namespace ModuleFrontend.Api.DAL
{
    [ExcludeFromCodeCoverage]
    public class ModuleContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Specialisatie> Specialisaties { get; set; }
        public DbSet<Moduleleider> Moduleleiders { get; set; }
        public DbSet<Periode> Periodes { get; set; }
        public DbSet<Studiefase> Studiefases { get; set; }
        public ModuleContext(DbContextOptions<ModuleContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>()
                .HasIndex(module => module.ModuleCode)
                .IsUnique();

            modelBuilder.Entity<Module>()
                .HasOne(m => m.Moduleleider)
                .WithMany();    

            modelBuilder.Entity<Module>()
                .HasOne(m => m.Studiefase)
                .WithMany();


            modelBuilder.Entity<Module>()
                .Ignore(m => m.Competenties);
            modelBuilder.Entity<Studiefase>()
                .Ignore(s => s.Periode);
        }
    }
}
