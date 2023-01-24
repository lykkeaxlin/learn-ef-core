using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Actor>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Actor>().Property(p => p.Biography).HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Cinema>().Property(p => p.Name).IsRequired();
            
            modelBuilder.Entity<CinemaHall>().Property(p => p.Cost).HasPrecision(9, 2);
            modelBuilder.Entity<CinemaHall>()
                .Property(p => p.CinemaHallType).HasDefaultValue(CinemaHallType.TwoDimensions);

            modelBuilder.Entity<Movie>().Property(p => p.Title).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Movie>().Property(p => p.PosterURL).HasMaxLength(500).IsUnicode(false);

            modelBuilder.Entity<CinemaOffer>().Property(p => p.DiscountPercentage).HasPrecision(5, 2);

            modelBuilder.Entity<MovieActor>().HasKey(p => new { p.MovieId, p.ActorId });
        }
    }
}
