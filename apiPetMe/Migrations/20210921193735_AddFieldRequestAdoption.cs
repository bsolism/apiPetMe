using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class AddFieldRequestAdoption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                schema: "dbo",
                table: "RequestAdoptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                schema: "dbo",
                table: "RequestAdoptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                schema: "dbo",
                table: "RequestAdoptions");

            migrationBuilder.DropColumn(
                name: "isApproved",
                schema: "dbo",
                table: "RequestAdoptions");
        }
    }
}
