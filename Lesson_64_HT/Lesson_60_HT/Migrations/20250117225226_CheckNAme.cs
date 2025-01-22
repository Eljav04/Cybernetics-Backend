using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson_60_HT.Migrations
{
    /// <inheritdoc />
    public partial class CheckNAme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "StudentsList",
                type: "VARCHAR(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Studetns_Name_Minimum",
                table: "StudentsList",
                sql: "LEN(StudentName) >= 2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Studetns_Name_Minimum",
                table: "StudentsList");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "StudentsList",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)",
                oldMaxLength: 30);
        }
    }
}
