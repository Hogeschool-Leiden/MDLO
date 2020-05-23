using CompetentieAppFrontend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetentieAppFrontend.Infrastructure.Configuration
{
    public class PeriodeConfiguration : IEntityTypeConfiguration<Periode>
    {
        public void Configure(EntityTypeBuilder<Periode> builder)
        {
            
        }
    }
}