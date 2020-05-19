using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CompetentieAppFrontend.Infrastructure.DAL
{
    public class CompetentieAppFrontendContext : DbContext
    {
        public CompetentieAppFrontendContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Specialisatie> Specialisaties { get; set; }
        public DbSet<Periode> Perioden { get; set; }
        public DbSet<Studiefase> Studiefasen { get; set; }
        public DbSet<Competentie> Competenties { get; set; }
        public DbSet<ArchitectuurLaag> ArchitectuurLagen { get; set; }
        public DbSet<BeheersingsNiveau> BeheersingsNiveaus { get; set; }
        public DbSet<Activiteit> Activiteiten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new CompetentieConfiguration())
                .ApplyConfiguration(new BeheersingsNiveauConfiguration())
                .ApplyConfiguration(new StudiefaseConfiguration());
        }
    }
}