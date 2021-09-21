using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPetMe.Migrations
{
    public partial class RequestAdoption2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestAdoption_Pets_PetId",
                schema: "dbo",
                table: "RequestAdoption");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestAdoption_ProfileHouses_ProfileHouseId",
                schema: "dbo",
                table: "RequestAdoption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestAdoption",
                schema: "dbo",
                table: "RequestAdoption");

            migrationBuilder.RenameTable(
                name: "RequestAdoption",
                schema: "dbo",
                newName: "RequestAdoptions",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_RequestAdoption_ProfileHouseId",
                schema: "dbo",
                table: "RequestAdoptions",
                newName: "IX_RequestAdoptions_ProfileHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestAdoption_PetId",
                schema: "dbo",
                table: "RequestAdoptions",
                newName: "IX_RequestAdoptions_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestAdoptions",
                schema: "dbo",
                table: "RequestAdoptions",
                column: "RequestAdoptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAdoptions_Pets_PetId",
                schema: "dbo",
                table: "RequestAdoptions",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAdoptions_ProfileHouses_ProfileHouseId",
                schema: "dbo",
                table: "RequestAdoptions",
                column: "ProfileHouseId",
                principalTable: "ProfileHouses",
                principalColumn: "ProfileHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestAdoptions_Pets_PetId",
                schema: "dbo",
                table: "RequestAdoptions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestAdoptions_ProfileHouses_ProfileHouseId",
                schema: "dbo",
                table: "RequestAdoptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestAdoptions",
                schema: "dbo",
                table: "RequestAdoptions");

            migrationBuilder.RenameTable(
                name: "RequestAdoptions",
                schema: "dbo",
                newName: "RequestAdoption",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_RequestAdoptions_ProfileHouseId",
                schema: "dbo",
                table: "RequestAdoption",
                newName: "IX_RequestAdoption_ProfileHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestAdoptions_PetId",
                schema: "dbo",
                table: "RequestAdoption",
                newName: "IX_RequestAdoption_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestAdoption",
                schema: "dbo",
                table: "RequestAdoption",
                column: "RequestAdoptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAdoption_Pets_PetId",
                schema: "dbo",
                table: "RequestAdoption",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAdoption_ProfileHouses_ProfileHouseId",
                schema: "dbo",
                table: "RequestAdoption",
                column: "ProfileHouseId",
                principalTable: "ProfileHouses",
                principalColumn: "ProfileHouseId");
        }
    }
}
