using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlDatabase.Migrations
{
    public partial class AddPriceFieldl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Category_CategoryId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_CategoryId",
                table: "Price");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_PriceId",
                table: "Category",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Price_PriceId",
                table: "Category",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Price_PriceId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_PriceId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Price_CategoryId",
                table: "Price",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Category_CategoryId",
                table: "Price",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
