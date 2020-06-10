using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class CohortConfiguration : IEntityTypeConfiguration<Cohort>
    {
        public void Configure(EntityTypeBuilder<Cohort> builder)
        {

            
            builder
                .HasMany(cohort => cohort.Modules)
                .WithOne(module => module.Cohort)
                .HasForeignKey(module => module.CohortId);
        }
    }
}