using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class BeheersingsNiveauConfiguration : IEntityTypeConfiguration<BeheersingsNiveau>
    {
        public void Configure(EntityTypeBuilder<BeheersingsNiveau> builder)
        {
            builder
                .HasOne(niveau => niveau.ArchitectuurLaag)
                .WithMany(laag => laag.BeheersingsNiveaus)
                .HasForeignKey(niveau => niveau.ArchitectuurLaagId);

            builder
                .HasOne(niveau => niveau.Activiteit)
                .WithMany(activiteit => activiteit.BeheersingsNiveaus)
                .HasForeignKey(niveau => niveau.ActiviteitId);
        }
    }
}