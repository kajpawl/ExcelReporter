using Microsoft.EntityFrameworkCore.Migrations;

namespace ExcelReporter.Data.Migrations
{
    public partial class Updatemodelrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_ProjectSheets_ProjectSheetId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectSheets_ProjectSheetId",
                table: "ProjectTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectSheets",
                table: "ProjectSheets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectSheets");

            migrationBuilder.AddColumn<string>(
                name: "ProjectSheetId",
                table: "ProjectSheets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectSheets",
                table: "ProjectSheets",
                column: "ProjectSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_ProjectSheets_ProjectSheetId",
                table: "Holidays",
                column: "ProjectSheetId",
                principalTable: "ProjectSheets",
                principalColumn: "ProjectSheetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_ProjectSheets_ProjectSheetId",
                table: "ProjectTasks",
                column: "ProjectSheetId",
                principalTable: "ProjectSheets",
                principalColumn: "ProjectSheetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_ProjectSheets_ProjectSheetId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectSheets_ProjectSheetId",
                table: "ProjectTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectSheets",
                table: "ProjectSheets");

            migrationBuilder.DropColumn(
                name: "ProjectSheetId",
                table: "ProjectSheets");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ProjectSheets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectSheets",
                table: "ProjectSheets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_ProjectSheets_ProjectSheetId",
                table: "Holidays",
                column: "ProjectSheetId",
                principalTable: "ProjectSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_ProjectSheets_ProjectSheetId",
                table: "ProjectTasks",
                column: "ProjectSheetId",
                principalTable: "ProjectSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
