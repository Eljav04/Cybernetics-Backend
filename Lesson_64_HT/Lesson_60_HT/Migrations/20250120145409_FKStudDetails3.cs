using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson_60_HT.Migrations
{
    /// <inheritdoc />
    public partial class FKStudDetails3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentDetailsID",
                table: "StudentsList",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsList_StudentDetailsID",
                table: "StudentsList",
                column: "StudentDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsList_StudentDetails_StudentDetailsID",
                table: "StudentsList",
                column: "StudentDetailsID",
                principalTable: "StudentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsList_StudentDetails_StudentDetailsID",
                table: "StudentsList");

            migrationBuilder.DropIndex(
                name: "IX_StudentsList_StudentDetailsID",
                table: "StudentsList");

            migrationBuilder.DropColumn(
                name: "StudentDetailsID",
                table: "StudentsList");
        }
    }
}
