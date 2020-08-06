using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleAuthAPI.Migrations.LargeData
{
    public partial class InitLargeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Test11 = table.Column<string>(nullable: true),
                    Test111 = table.Column<string>(nullable: true),
                    Test22 = table.Column<string>(nullable: true),
                    Test222 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
