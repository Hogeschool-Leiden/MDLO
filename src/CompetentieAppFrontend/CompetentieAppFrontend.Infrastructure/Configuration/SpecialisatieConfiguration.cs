using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class SpecialisatieConfiguration : IEntityTypeConfiguration<Specialisatie>
    {
        public void Configure(EntityTypeBuilder<Specialisatie> builder)
        {
            
        }
    }
}