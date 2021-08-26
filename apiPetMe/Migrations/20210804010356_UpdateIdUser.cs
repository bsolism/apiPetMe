using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class UpdateIdUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Users",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "ClientId");
        }
    }
}
