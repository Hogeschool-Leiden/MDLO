using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class ArchitectuurLaagConfiguration : IEntityTypeConfiguration<ArchitectuurLaag>
    {
        public void Configure(EntityTypeBuilder<ArchitectuurLaag> builder)
        {

        }
    }
}