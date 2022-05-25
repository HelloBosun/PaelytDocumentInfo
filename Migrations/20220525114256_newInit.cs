using Microsoft.EntityFrameworkCore.Migrations;

namespace Paelyt_Data_System.Migrations
{
    public partial class newInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalImages_PersonalData_PersonalDataId",
                table: "PersonalImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalData",
                table: "PersonalData");

            migrationBuilder.RenameTable(
                name: "PersonalData",
                newName: "PersonalDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalDatas",
                table: "PersonalDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalImages_PersonalDatas_PersonalDataId",
                table: "PersonalImages",
                column: "PersonalDataId",
                principalTable: "PersonalDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalImages_PersonalDatas_PersonalDataId",
                table: "PersonalImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalDatas",
                table: "PersonalDatas");

            migrationBuilder.RenameTable(
                name: "PersonalDatas",
                newName: "PersonalData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalData",
                table: "PersonalData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalImages_PersonalData_PersonalDataId",
                table: "PersonalImages",
                column: "PersonalDataId",
                principalTable: "PersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
