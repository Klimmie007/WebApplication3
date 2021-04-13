using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class addedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FizzBuzzes",
                table: "FizzBuzzes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FizzBuzzes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FizzBuzzes",
                table: "FizzBuzzes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FizzBuzzes",
                table: "FizzBuzzes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FizzBuzzes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FizzBuzzes",
                table: "FizzBuzzes",
                column: "Date");
        }
    }
}
