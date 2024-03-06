using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JupilerLeague.Migrations
{
    /// <inheritdoc />
    public partial class New2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kolejka1Herb2",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kolejka2Herb2",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kolejka2Nazwa2",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolejka1Herb2",
                table: "TeamViewModel");

            migrationBuilder.DropColumn(
                name: "Kolejka2Herb2",
                table: "TeamViewModel");

            migrationBuilder.DropColumn(
                name: "Kolejka2Nazwa2",
                table: "TeamViewModel");
        }
    }
}
