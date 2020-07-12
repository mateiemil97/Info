using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlDatabase.Migrations
{
    public partial class sp_getHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_GetHistory = @"CREATE PROCEDURE [sp_getHistory]
                                 AS
                                 BEGIN
                                 
                                 SET NOCOUNT ON
                                 SELECT * FROM History
                                 END";
            migrationBuilder.Sql(sp_GetHistory);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
