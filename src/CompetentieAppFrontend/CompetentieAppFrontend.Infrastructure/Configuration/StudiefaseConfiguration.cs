using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class StudiefaseConfiguration : IEntityTypeConfiguration<Studiefase>
    {
        public void Configure(EntityTypeBuilder<Studiefase> builder)
        {
            builder.HasKey(studiefase => new {studiefase.ModuleId, studiefase.PeriodeId, studiefase.SpecialisatieId});

            builder
                .HasOne(studiefase => studiefase.Module)
                .WithMany(module => module.Studiefasen)
                .HasForeignKey(studiefase => studiefase.ModuleId);

            builder
                .HasOne(studiefase => studiefase.Periode)
                .WithMany(periode => periode.Studiefasen)
                .HasForeignKey(studiefase => studiefase.PeriodeId);

            builder
                .HasOne(studiefase => studiefase.Specialisatie)
                .WithMany(specialisatie => specialisatie.Studiefasen)
                .HasForeignKey(studiefase => studiefase.SpecialisatieId);
        }
    }
}