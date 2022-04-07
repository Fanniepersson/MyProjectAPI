using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProjectAPI.API.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimReports",
                columns: table => new
                {
                    ReportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Week = table.Column<int>(nullable: false),
                    wWorkingHours = table.Column<double>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimReports", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_TimReports_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ProjectName" },
                values: new object[] { 1, "Project 1" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ProjectName" },
                values: new object[] { 2, "Project 2" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ProjectName" },
                values: new object[] { 3, "Project 3" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "FName", "LName", "ProjectID" },
                values: new object[,]
                {
                    { 1, "jasmine@company.se", "Jasmine", "Coleman", 1 },
                    { 2, "lucas@company.se", "Lucas", "Brown", 1 },
                    { 3, "liam@company.se", "Liam", "Mackay", 1 },
                    { 4, "emily@company.se", "Emily", "Young", 2 },
                    { 5, "dylan@company.se", "Dylan", "Terry", 2 },
                    { 6, "carolyn@company.se", "Carolyn", "North", 2 },
                    { 7, "sue@company.se", "Sue", "McKenzie", 2 },
                    { 8, "brian@company.se", "Brian", "Hamilton", 3 },
                    { 9, "leah@company.se", "Leah", "Ellison", 3 },
                    { 10, "adrian@company.se", "Adrian", "Walsh", 3 }
                });

            migrationBuilder.InsertData(
                table: "TimReports",
                columns: new[] { "ReportID", "EmployeeID", "Week", "wWorkingHours" },
                values: new object[,]
                {
                    { 1, 1, 1, 20.0 },
                    { 2, 2, 1, 45.0 },
                    { 3, 3, 1, 50.0 },
                    { 4, 4, 1, 30.0 },
                    { 5, 5, 1, 40.0 },
                    { 6, 6, 1, 40.0 },
                    { 7, 7, 1, 40.0 },
                    { 8, 8, 1, 15.0 },
                    { 9, 9, 1, 40.0 },
                    { 10, 10, 1, 25.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectID",
                table: "Employees",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TimReports_EmployeeID",
                table: "TimReports",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
