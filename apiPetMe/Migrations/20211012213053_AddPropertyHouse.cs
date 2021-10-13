using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class AddPropertyHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountBank",
                table: "ProfileHouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "ProfileHouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rtn",
                table: "ProfileHouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeAccount",
                table: "ProfileHouses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBank",
                table: "ProfileHouses");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "ProfileHouses");

            migrationBuilder.DropColumn(
                name: "Rtn",
                table: "ProfileHouses");

            migrationBuilder.DropColumn(
                name: "TypeAccount",
                table: "ProfileHouses");
        }
    }
}
