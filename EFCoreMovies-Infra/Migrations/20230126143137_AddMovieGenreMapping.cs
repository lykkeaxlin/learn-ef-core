using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMoviesInfra.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieGenreMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.CreateTable(
                name: "MovieActorMappings",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActorMappings", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActorMappings_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActorMappings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenreMappings",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenreMappings", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenreMappings_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenreMappings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MovieActorMappings",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[,]
                {
                    { 3, 1, "Iron Man", 2 },
                    { 4, 1, "Capitán América", 1 },
                    { 7, 1, "Black Widow", 3 },
                    { 1, 3, "Peter Parker", 1 },
                    { 1, 4, "Peter Parker", 1 },
                    { 2, 4, "Samuel L. Jackson", 2 },
                    { 8, 5, "Neo", 1 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenreMappings",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 },
                    { 1, 3 },
                    { 3, 4 },
                    { 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActorMappings_ActorId",
                table: "MovieActorMappings",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenreMappings_GenreId",
                table: "MovieGenreMappings",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActorMappings");

            migrationBuilder.DropTable(
                name: "MovieGenreMappings");

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[,]
                {
                    { 3, 1, "Iron Man", 2 },
                    { 4, 1, "Capitán América", 1 },
                    { 7, 1, "Black Widow", 3 },
                    { 1, 3, "Peter Parker", 1 },
                    { 1, 4, "Peter Parker", 1 },
                    { 2, 4, "Samuel L. Jackson", 2 },
                    { 8, 5, "Neo", 1 }
                });
        }
    }
}
