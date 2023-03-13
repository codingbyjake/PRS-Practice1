using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRS_Practice1.Migrations
{
    public partial class fixedDecimalAndDefaultProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Requests",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "decimal,(11,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "decimal,(11,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Total",
                table: "Requests",
                type: "decimal,(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Products",
                type: "decimal,(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");
        }
    }
}
