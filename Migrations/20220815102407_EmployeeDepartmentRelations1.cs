using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Migrations
{
    public partial class EmployeeDepartmentRelations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "EmployeeEntity");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "DepartmentEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "EmployeeEntity",
                newName: "IX_EmployeeEntity_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEntity",
                table: "EmployeeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentEntity",
                table: "DepartmentEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEntity_DepartmentEntity_DepartmentId",
                table: "EmployeeEntity",
                column: "DepartmentId",
                principalTable: "DepartmentEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEntity_DepartmentEntity_DepartmentId",
                table: "EmployeeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEntity",
                table: "EmployeeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentEntity",
                table: "DepartmentEntity");

            migrationBuilder.RenameTable(
                name: "EmployeeEntity",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "DepartmentEntity",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEntity_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
