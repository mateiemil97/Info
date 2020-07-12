using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlDatabase.Migrations
{
    public partial class AddStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_selectHistory = @"CREATE PROCEDURE [GetHistory]
                      AS
                      BEGIN
                      SELECT * FROM HISTORY
                      END
                      ";
            migrationBuilder.Sql(sp_selectHistory);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
