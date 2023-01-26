using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Core.BusinessModel.Entitiy.Configurations
{
    public class MovieGenreConfig : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.GenreId });
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieGenresMapping).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.Genre).WithMany(x => x.MovieGenresMapping).HasForeignKey(x => x.GenreId);
        }
    }
}
