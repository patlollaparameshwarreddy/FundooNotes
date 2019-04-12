using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooNotes.Migrations
{
    public partial class collaboratorchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "collaborators");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "collaborators",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "collaborators");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "collaborators",
                nullable: true);
        }
    }
}
