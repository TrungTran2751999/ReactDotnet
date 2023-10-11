using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    idSystem = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.idSystem);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    idSystem = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.idSystem);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Idsystem = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Idsystem);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    idSystem = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentCode = table.Column<long>(type: "bigint", nullable: true),
                    studentGrade = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.idSystem);
                    table.ForeignKey(
                        name: "FK_Students_Codes_studentCode",
                        column: x => x.studentCode,
                        principalTable: "Codes",
                        principalColumn: "idSystem");
                    table.ForeignKey(
                        name: "FK_Students_Grades_studentGrade",
                        column: x => x.studentGrade,
                        principalTable: "Grades",
                        principalColumn: "idSystem");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_studentCode",
                table: "Students",
                column: "studentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Students_studentGrade",
                table: "Students",
                column: "studentGrade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
