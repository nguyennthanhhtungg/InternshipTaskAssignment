using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskAssignment.Migrations
{
    public partial class EmployeeDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptID",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptID",
                table: "Employee",
                type: "int",
                nullable: true);
        }
    }
}
