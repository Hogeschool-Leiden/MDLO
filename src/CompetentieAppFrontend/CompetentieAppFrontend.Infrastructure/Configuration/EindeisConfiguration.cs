using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class EindeisConfiguration : IEntityTypeConfiguration<Eindeis>
    {
        public void Configure(EntityTypeBuilder<Eindeis> builder)
        {
            builder
                .HasOne(eindeis => eindeis.Module)
                .WithMany(module => module.Eindeisen)
                .HasForeignKey(eindeis => eindeis.Id);
        }
    }
}