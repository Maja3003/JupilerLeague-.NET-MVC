using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JupilerLeague.Migrations
{
    /// <inheritdoc />
    public partial class New1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kolejka1Nazwa2",
                table: "TeamViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolejka1Nazwa2",
                table: "TeamViewModel");
        }
    }
}
