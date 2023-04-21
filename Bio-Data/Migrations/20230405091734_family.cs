using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bio_Data.Migrations
{
    public partial class family : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "familydetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FatherName = table.Column<string>(type: "text", nullable: true),
                    FatherOccupation = table.Column<string>(type: "text", nullable: true),
                    MotherName = table.Column<string>(type: "text", nullable: true),
                    MotherOccupation = table.Column<string>(type: "text", nullable: true),
                    ElderBrotherName = table.Column<string>(type: "text", nullable: true),
                    ElderBrotherOccupation = table.Column<string>(type: "text", nullable: true),
                    YoungerBrotherName = table.Column<string>(type: "text", nullable: true),
                    YoungerBrotherOccupation = table.Column<string>(type: "text", nullable: true),
                    ElderSisterName = table.Column<string>(type: "text", nullable: true),
                    ElderSisterOccupation = table.Column<string>(type: "text", nullable: true),
                    YoungerSisterName = table.Column<string>(type: "text", nullable: true),
                    YoungerSisterOccupation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familydetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "familydetails");
        }
    }
}
