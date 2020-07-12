using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlDatabase.Migrations
{
    public partial class sdc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_getHistoryByEmpId = @"CREATE PROCEDURE [sp_getHistoryByEmpId] 
                                        @empId int
                                        AS
                                        BEGIN
                                        SET NOCOUNT ON
                                        SELECT * FROM History h
                                        WHERE h.EmployeeId = @empId
                                        END
                                    ";
            migrationBuilder.Sql(sp_getHistoryByEmpId);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
