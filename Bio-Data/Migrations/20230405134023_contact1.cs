using Microsoft.EntityFrameworkCore.Migrations;

namespace Bio_Data.Migrations
{
    public partial class contact1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "contactdetails",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "contactdetails");
        }
    }
}
