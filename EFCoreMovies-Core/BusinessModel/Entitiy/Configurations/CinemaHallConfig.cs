using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class CinemaHallConfig : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {

            builder.Property(p => p.Cost).HasPrecision(9, 2);
            builder.Property(p => p.CinemaHallType)
                .HasDefaultValue(CinemaHallType.TwoDimensions);
        }
    }
}
