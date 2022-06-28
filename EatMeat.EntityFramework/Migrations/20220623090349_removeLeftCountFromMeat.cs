using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatMeat.EntityFramework.Migrations
{
    public partial class removeLeftCountFromMeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Left",
                table: "Meats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Left",
                table: "Meats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
