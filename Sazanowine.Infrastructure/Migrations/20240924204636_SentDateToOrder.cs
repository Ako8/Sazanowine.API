using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sazanowine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SentDateToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderSentDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderSentDate",
                table: "Orders");
        }
    }
}
