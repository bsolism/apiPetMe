using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class hasheo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Sal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sal",
                table: "Users",
                newName: "UserName");
        }
    }
}
