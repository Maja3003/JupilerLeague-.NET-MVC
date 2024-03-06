using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JupilerLeague.Migrations
{
    /// <inheritdoc />
    public partial class New6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kolejka2Wynik",
                table: "TeamViewModel",
                newName: "Wynik4");

            migrationBuilder.RenameColumn(
                name: "Kolejka1Wynik",
                table: "TeamViewModel",
                newName: "Wynik3");

            migrationBuilder.AddColumn<string>(
                name: "Wynik1",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wynik2",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wynik1",
                table: "TeamViewModel");

            migrationBuilder.DropColumn(
                name: "Wynik2",
                table: "TeamViewModel");

            migrationBuilder.RenameColumn(
                name: "Wynik4",
                table: "TeamViewModel",
                newName: "Kolejka2Wynik");

            migrationBuilder.RenameColumn(
                name: "Wynik3",
                table: "TeamViewModel",
                newName: "Kolejka1Wynik");
        }
    }
}
