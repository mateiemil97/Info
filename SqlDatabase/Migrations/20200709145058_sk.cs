using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlDatabase.Migrations
{
    public partial class sk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_PriceId",
                table: "Category",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_LocationId",
                table: "Price",
                column: "LocationId");

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

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Category_PriceId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Category");
        }
    }
}
