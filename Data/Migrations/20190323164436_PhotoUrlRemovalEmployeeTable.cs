using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PhotoUrlRemovalEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Employees",
                maxLength: 255,
                nullable: true);
        }
    }
}
