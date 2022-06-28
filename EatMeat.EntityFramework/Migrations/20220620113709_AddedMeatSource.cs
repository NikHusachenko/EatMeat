using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatMeat.EntityFramework.Migrations
{
    public partial class AddedMeatSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "Meats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Meats");
        }
    }
}
