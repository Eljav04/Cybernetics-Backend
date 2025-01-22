using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson_60_HT.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubjectsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "VARCHAR", nullable: false),
                    StudentSurname = table.Column<string>(type: "VARCHAR", nullable: false),
                    StudentAge = table.Column<int>(type: "INT", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsList_SubjectsList_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SubjectsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsList_SubjectID",
                table: "StudentsList",
                column: "SubjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsList");

            migrationBuilder.DropTable(
                name: "SubjectsList");
        }
    }
}
