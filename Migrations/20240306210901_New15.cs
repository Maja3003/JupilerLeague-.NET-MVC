using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JupilerLeague.Migrations
{
    /// <inheritdoc />
    public partial class New15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewFavouriteTeams_AspNetUsers_UserId",
                table: "NewFavouriteTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_NewFavouriteTeams_TeamViewModel_TeamId",
                table: "NewFavouriteTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewFavouriteTeams",
                table: "NewFavouriteTeams");

            migrationBuilder.RenameTable(
                name: "NewFavouriteTeams",
                newName: "FavouriteTeam");

            migrationBuilder.RenameIndex(
                name: "IX_NewFavouriteTeams_UserId",
                table: "FavouriteTeam",
                newName: "IX_FavouriteTeam_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NewFavouriteTeams_TeamId",
                table: "FavouriteTeam",
                newName: "IX_FavouriteTeam_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteTeam",
                table: "FavouriteTeam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteTeam_AspNetUsers_UserId",
                table: "FavouriteTeam",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteTeam_TeamViewModel_TeamId",
                table: "FavouriteTeam",
                column: "TeamId",
                principalTable: "TeamViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteTeam_AspNetUsers_UserId",
                table: "FavouriteTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteTeam_TeamViewModel_TeamId",
                table: "FavouriteTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteTeam",
                table: "FavouriteTeam");

            migrationBuilder.RenameTable(
                name: "FavouriteTeam",
                newName: "NewFavouriteTeams");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteTeam_UserId",
                table: "NewFavouriteTeams",
                newName: "IX_NewFavouriteTeams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteTeam_TeamId",
                table: "NewFavouriteTeams",
                newName: "IX_NewFavouriteTeams_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewFavouriteTeams",
                table: "NewFavouriteTeams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewFavouriteTeams_AspNetUsers_UserId",
                table: "NewFavouriteTeams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewFavouriteTeams_TeamViewModel_TeamId",
                table: "NewFavouriteTeams",
                column: "TeamId",
                principalTable: "TeamViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
