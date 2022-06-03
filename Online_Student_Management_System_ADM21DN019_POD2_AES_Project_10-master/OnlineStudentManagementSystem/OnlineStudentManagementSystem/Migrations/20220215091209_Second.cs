using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStudentManagementSystem.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectName",
                table: "Subjects",
                column: "SubjectName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subjects_SubjectName",
                table: "Subjects");
        }
    }
}
