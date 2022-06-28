using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatMeat.EntityFramework.Migrations
{
    public partial class ChangeColumnNameToDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "Meats",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Meats",
                newName: "Discription");
        }
    }
}
