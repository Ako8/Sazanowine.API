using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sazanowine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VinatageYearToWine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VintageYear",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VintageYear",
                table: "Wines");
        }
    }
}
