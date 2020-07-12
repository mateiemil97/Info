using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlDatabase.Migrations
{
    public partial class AddValueToHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "History",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "History");
        }
    }
}
