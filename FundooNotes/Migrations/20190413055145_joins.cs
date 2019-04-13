using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooNotes.Migrations
{
    public partial class joins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "notesModelId",
                table: "collaborators",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_collaborators_notesModelId",
                table: "collaborators",
                column: "notesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_collaborators_Notes_notesModelId",
                table: "collaborators",
                column: "notesModelId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collaborators_Notes_notesModelId",
                table: "collaborators");

            migrationBuilder.DropIndex(
                name: "IX_collaborators_notesModelId",
                table: "collaborators");

            migrationBuilder.DropColumn(
                name: "notesModelId",
                table: "collaborators");
        }
    }
}
