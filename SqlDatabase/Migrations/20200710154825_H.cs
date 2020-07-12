using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlDatabase.Migrations
{
    public partial class H : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Category_CategoryId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Location_LocationId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_LocationId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "History");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "History",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Category_CategoryId",
                table: "History",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Category_CategoryId",
                table: "History");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "History",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "History",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_History_LocationId",
                table: "History",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Category_CategoryId",
                table: "History",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Location_LocationId",
                table: "History",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
