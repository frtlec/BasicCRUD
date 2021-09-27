using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicCRUD.DataAccess.Migrations
{
    public partial class EditAppLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullMethodName",
                table: "AppLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullMethodName",
                table: "AppLogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
