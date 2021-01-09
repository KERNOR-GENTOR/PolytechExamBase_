using Microsoft.EntityFrameworkCore.Migrations;

namespace PolytechExamBase.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBUsers",
                columns: table => new
                {
                    Fucking_User_ID = table.Column<long>(nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    Role = table.Column<string>(maxLength: 20, nullable: true),
                    First_Name = table.Column<string>(maxLength: 20, nullable: true),
                    Last_Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DBUsers_PK", x => x.Fucking_User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Task_ID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Code_To_Test = table.Column<string>(maxLength: 3999, nullable: true),
                    Unit_Test = table.Column<string>(maxLength: 2048, nullable: true),
                    Difficulty = table.Column<string>(maxLength: 20, nullable: true),
                    Topic = table.Column<string>(maxLength: 40, nullable: true),
                    Teacher_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Task_PK", x => x.Task_ID);
                    table.ForeignKey(
                        name: "Task_DBUsers_FK",
                        column: x => x.Teacher_ID,
                        principalTable: "DBUsers",
                        principalColumn: "Fucking_User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passed_Tasks",
                columns: table => new
                {
                    Passed_Task_ID = table.Column<long>(nullable: false),
                    User_ID = table.Column<long>(nullable: false),
                    Task_ID = table.Column<long>(nullable: false),
                    Code_Answer = table.Column<string>(maxLength: 2048, nullable: true),
                    Successful = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Passed_Task_PK", x => x.Passed_Task_ID);
                    table.ForeignKey(
                        name: "Passed_Task_Task_FK",
                        column: x => x.Task_ID,
                        principalTable: "Tasks",
                        principalColumn: "Task_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Passed_Task_DBUsers_FK",
                        column: x => x.User_ID,
                        principalTable: "DBUsers",
                        principalColumn: "Fucking_User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Mark_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passed_Task_ID = table.Column<long>(nullable: false),
                    Mark = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Marks_PK", x => x.Mark_ID);
                    table.ForeignKey(
                        name: "Marks_Passed_Tasks_FK",
                        column: x => x.Passed_Task_ID,
                        principalTable: "Passed_Tasks",
                        principalColumn: "Passed_Task_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_Passed_Task_ID",
                table: "Marks",
                column: "Passed_Task_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Passed_Tasks_Task_ID",
                table: "Passed_Tasks",
                column: "Task_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Passed_Tasks_User_ID",
                table: "Passed_Tasks",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Teacher_ID",
                table: "Tasks",
                column: "Teacher_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Passed_Tasks");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "DBUsers");
        }
    }
}
