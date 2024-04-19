using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class _5tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentClasses_StudentClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentClassId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "FKStudentClassId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FKStudentClassId",
                table: "Students",
                column: "FKStudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentClasses_FKStudentClassId",
                table: "Students",
                column: "FKStudentClassId",
                principalTable: "StudentClasses",
                principalColumn: "StudentClassId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentClasses_FKStudentClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FKStudentClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FKStudentClassId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentClassId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentClassId",
                table: "Students",
                column: "StudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentClasses_StudentClassId",
                table: "Students",
                column: "StudentClassId",
                principalTable: "StudentClasses",
                principalColumn: "StudentClassId");
        }
    }
}
