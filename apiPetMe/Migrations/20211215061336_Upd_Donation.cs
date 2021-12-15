using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class Upd_Donation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                schema: "dbo",
                table: "Donation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Suscription",
                schema: "dbo",
                table: "Donation",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prefix",
                schema: "dbo",
                table: "Donation");

            migrationBuilder.DropColumn(
                name: "Suscription",
                schema: "dbo",
                table: "Donation");
        }
    }
}
