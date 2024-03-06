using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JupilerLeague.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kolejka1Herb",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kolejka1Nazwa",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kolejka1Wynik",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kolejka2Herb",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kolejka2Nazwa",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kolejka2Wynik",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolejka1Herb",
                table: "TeamViewModel");

            migrationBuilder.DropColumn(
                name: "Kolejka1Nazwa",
                table: "TeamViewModel");

            migrationBuilder.DropColumn(
                name: "Kolejka1Wynik",
                table: "TeamViewModel");

            migrationBuilder.DropColumn(
                name: "Kolejka2Herb",
                table: "TeamViewModel");

            migrationBuilder.DropColumn(
                name: "Kolejka2Nazwa",
                table: "TeamViewModel");

            migrationBuilder.DropColumn(
                name: "Kolejka2Wynik",
                table: "TeamViewModel");
        }
    }
}
