using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRS_Practice1.Migrations
{
    public partial class usersFirstnameSpellingCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fristname",
                table: "Users",
                newName: "Firstname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Users",
                newName: "Fristname");
        }
    }
}
