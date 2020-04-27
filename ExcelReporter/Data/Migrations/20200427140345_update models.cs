using Microsoft.EntityFrameworkCore.Migrations;

namespace ExcelReporter.Data.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectSheets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserLogin = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProjectSheetId = table.Column<string>(nullable: true),
                    UserLogin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateStarted = table.Column<string>(nullable: true),
                    DateEnded = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_ProjectSheets_ProjectSheetId",
                        column: x => x.ProjectSheetId,
                        principalTable: "ProjectSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProjectSheetId = table.Column<string>(nullable: true),
                    UserLogin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateStarted = table.Column<string>(nullable: true),
                    DateEnded = table.Column<string>(nullable: true),
                    TaskId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Others = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_ProjectSheets_ProjectSheetId",
                        column: x => x.ProjectSheetId,
                        principalTable: "ProjectSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_ProjectSheetId",
                table: "Holidays",
                column: "ProjectSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectSheetId",
                table: "ProjectTasks",
                column: "ProjectSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "ProjectSheets");
        }
    }
}
