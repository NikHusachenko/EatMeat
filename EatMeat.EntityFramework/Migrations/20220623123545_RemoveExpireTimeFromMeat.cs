using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatMeat.EntityFramework.Migrations
{
    public partial class RemoveExpireTimeFromMeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "Meats");

            migrationBuilder.RenameColumn(
                name: "Types",
                table: "Meats",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Meats",
                newName: "Types");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expiration",
                table: "Meats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
