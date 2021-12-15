using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class AddfieldisRejectedrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isRejected",
                schema: "dbo",
                table: "RequestAdoptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isRejected",
                schema: "dbo",
                table: "RequestAdoptions");
        }
    }
}
