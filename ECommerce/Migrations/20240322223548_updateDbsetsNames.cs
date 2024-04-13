using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class updateDbsetsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_actors_ActorId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_movies_MovieId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_cinemas_CinemaId",
                table: "movies");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_producers_ProducerId",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_producers",
                table: "producers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cinemas",
                table: "cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actors",
                table: "actors");

            migrationBuilder.RenameTable(
                name: "producers",
                newName: "Producers");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "cinemas",
                newName: "Cinemas");

            migrationBuilder.RenameTable(
                name: "actors",
                newName: "Actors");

            migrationBuilder.RenameIndex(
                name: "IX_movies_ProducerId",
                table: "Movies",
                newName: "IX_Movies_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_movies_CinemaId",
                table: "Movies",
                newName: "IX_Movies_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producers",
                table: "Producers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Actors_ActorId",
                table: "ActorMovies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Movies_MovieId",
                table: "ActorMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Producers_ProducerId",
                table: "Movies",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Actors_ActorId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Movies_MovieId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Producers_ProducerId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producers",
                table: "Producers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "Producers",
                newName: "producers");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "Cinemas",
                newName: "cinemas");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "actors");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_ProducerId",
                table: "movies",
                newName: "IX_movies_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CinemaId",
                table: "movies",
                newName: "IX_movies_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_producers",
                table: "producers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cinemas",
                table: "cinemas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_actors",
                table: "actors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_actors_ActorId",
                table: "ActorMovies",
                column: "ActorId",
                principalTable: "actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_movies_MovieId",
                table: "ActorMovies",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_cinemas_CinemaId",
                table: "movies",
                column: "CinemaId",
                principalTable: "cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_producers_ProducerId",
                table: "movies",
                column: "ProducerId",
                principalTable: "producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
