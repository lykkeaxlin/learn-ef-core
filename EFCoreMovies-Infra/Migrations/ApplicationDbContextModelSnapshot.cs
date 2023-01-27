﻿// <auto-generated />
using System;
using EFCoreMovies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreMoviesInfra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreMovies.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tom Holland"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Robert Downey Jr."
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chris Evans"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dwayne Johnson"
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Auli'i Cravalho"
                        },
                        new
                        {
                            Id = 7,
                            DateOfBirth = new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Scarlett Johansson"
                        },
                        new
                        {
                            Id = 8,
                            DateOfBirth = new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Keanu Reeves"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Agora Mall"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sambil"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Megacentro"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Acropolis"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CinemaHallType")
                        .HasColumnType("int");

                    b.Property<int?>("CinemaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("CinemaHalls");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            CinemaHallType = 1,
                            CinemaId = 3,
                            Cost = 250m
                        },
                        new
                        {
                            Id = 6,
                            CinemaHallType = 2,
                            CinemaId = 3,
                            Cost = 330m
                        },
                        new
                        {
                            Id = 7,
                            CinemaHallType = 3,
                            CinemaId = 3,
                            Cost = 450m
                        },
                        new
                        {
                            Id = 8,
                            CinemaHallType = 1,
                            CinemaId = 4,
                            Cost = 250m
                        },
                        new
                        {
                            Id = 1,
                            CinemaHallType = 1,
                            CinemaId = 1,
                            Cost = 220m
                        },
                        new
                        {
                            Id = 2,
                            CinemaHallType = 2,
                            CinemaId = 1,
                            Cost = 320m
                        },
                        new
                        {
                            Id = 3,
                            CinemaHallType = 1,
                            CinemaId = 2,
                            Cost = 200m
                        },
                        new
                        {
                            Id = 4,
                            CinemaHallType = 2,
                            CinemaId = 2,
                            Cost = 290m
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Begin")
                        .HasColumnType("Date");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("End")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId")
                        .IsUnique();

                    b.ToTable("CinemaOffers");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Begin = new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CinemaId = 4,
                            DiscountPercentage = 15m,
                            End = new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 1,
                            Begin = new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CinemaId = 1,
                            DiscountPercentage = 10m,
                            End = new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Animation"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Drama"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CinemaHallId")
                        .HasColumnType("int");

                    b.Property<bool>("InCinemas")
                        .HasColumnType("bit");

                    b.Property<string>("PosterURL")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("Date");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaHallId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InCinemas = false,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                            ReleaseDate = new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avengers"
                        },
                        new
                        {
                            Id = 2,
                            InCinemas = false,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg",
                            ReleaseDate = new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Coco"
                        },
                        new
                        {
                            Id = 3,
                            InCinemas = false,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            ReleaseDate = new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: No way home"
                        },
                        new
                        {
                            Id = 4,
                            InCinemas = false,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            ReleaseDate = new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: Far From Home"
                        },
                        new
                        {
                            Id = 5,
                            InCinemas = true,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
                            ReleaseDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Matrix Resurrections"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.MovieActor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("MovieActorMappings");

                    b.HasData(
                        new
                        {
                            MovieId = 4,
                            ActorId = 2,
                            Character = "Samuel L. Jackson",
                            Order = 2
                        },
                        new
                        {
                            MovieId = 4,
                            ActorId = 1,
                            Character = "Peter Parker",
                            Order = 1
                        },
                        new
                        {
                            MovieId = 3,
                            ActorId = 1,
                            Character = "Peter Parker",
                            Order = 1
                        },
                        new
                        {
                            MovieId = 1,
                            ActorId = 3,
                            Character = "Iron Man",
                            Order = 2
                        },
                        new
                        {
                            MovieId = 1,
                            ActorId = 7,
                            Character = "Black Widow",
                            Order = 3
                        },
                        new
                        {
                            MovieId = 1,
                            ActorId = 4,
                            Character = "Capitán América",
                            Order = 1
                        },
                        new
                        {
                            MovieId = 5,
                            ActorId = 8,
                            Character = "Neo",
                            Order = 1
                        });
                });

            modelBuilder.Entity("EFCoreMovies_Core.BusinessModel.Entitiy.MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenreMappings");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            GenreId = 5
                        },
                        new
                        {
                            MovieId = 3,
                            GenreId = 1
                        },
                        new
                        {
                            MovieId = 4,
                            GenreId = 3
                        },
                        new
                        {
                            MovieId = 5,
                            GenreId = 2
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaHall", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Cinema", null)
                        .WithMany("CinemaHalls")
                        .HasForeignKey("CinemaId");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaOffer", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Cinema", null)
                        .WithOne("CinemaOffer")
                        .HasForeignKey("EFCoreMovies.Entities.CinemaOffer", "CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Movie", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.CinemaHall", null)
                        .WithMany("Movies")
                        .HasForeignKey("CinemaHallId");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.MovieActor", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreMovies.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("EFCoreMovies_Core.BusinessModel.Entitiy.MovieGenre", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Genre", "Genre")
                        .WithMany("MovieGenresMapping")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreMovies.Entities.Movie", "Movie")
                        .WithMany("MovieGenresMapping")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Cinema", b =>
                {
                    b.Navigation("CinemaHalls");

                    b.Navigation("CinemaOffer");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaHall", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Genre", b =>
                {
                    b.Navigation("MovieGenresMapping");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Movie", b =>
                {
                    b.Navigation("MovieGenresMapping");
                });
#pragma warning restore 612, 618
        }
    }
}
