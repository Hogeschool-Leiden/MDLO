using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class ActiviteitConfiguration : IEntityTypeConfiguration<Activiteit>
    {
        public void Configure(EntityTypeBuilder<Activiteit> builder)
        {
 
        }
    }
}