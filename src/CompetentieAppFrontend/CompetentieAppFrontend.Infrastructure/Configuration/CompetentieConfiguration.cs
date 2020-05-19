using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class CompetentieConfiguration : IEntityTypeConfiguration<Competentie>
    {
        public void Configure(EntityTypeBuilder<Competentie> builder)
        {
            builder
                .HasKey(competentie => new
                    {competentie.ModuleId, ArchitectuurLaagId = competentie.BeheersingsNiveauId});

            builder
                .HasOne(competentie => competentie.Module)
                .WithMany(module => module.Competenties)
                .HasForeignKey(competentie => competentie.ModuleId);

            builder
                .HasOne(competentie => competentie.BeheersingsNiveau)
                .WithMany(niveau => niveau.Competenties)
                .HasForeignKey(competentie => competentie.BeheersingsNiveauId);
        }
    }
}