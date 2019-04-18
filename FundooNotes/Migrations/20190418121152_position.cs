using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooNotes.Migrations
{
    public partial class position : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "position",
                table: "Notes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "Notes");
        }
    }
}
