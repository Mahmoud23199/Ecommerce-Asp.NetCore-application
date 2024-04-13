using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class updateDbsetsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_cinemas_CinemaId",
                table: "ActorMovies");

            migrationBuilder.DropIndex(
                name: "IX_ActorMovies_CinemaId",
                table: "ActorMovies");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "ActorMovies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "ActorMovies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_CinemaId",
                table: "ActorMovies",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_cinemas_CinemaId",
                table: "ActorMovies",
                column: "CinemaId",
                principalTable: "cinemas",
                principalColumn: "Id");
        }
    }
}
