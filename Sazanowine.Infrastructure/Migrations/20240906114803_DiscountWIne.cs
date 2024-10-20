using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sazanowine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DiscountWIne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPrice",
                table: "Wines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscounted",
                table: "Wines",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "IsDiscounted",
                table: "Wines");
        }
    }
}
