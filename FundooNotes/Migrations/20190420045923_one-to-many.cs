using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooNotes.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collaborators_Notes_NotesModelId",
                table: "collaborators");

            migrationBuilder.RenameColumn(
                name: "NotesModelId",
                table: "collaborators",
                newName: "notesModelId");

            migrationBuilder.RenameIndex(
                name: "IX_collaborators_NotesModelId",
                table: "collaborators",
                newName: "IX_collaborators_notesModelId");

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

            migrationBuilder.RenameColumn(
                name: "notesModelId",
                table: "collaborators",
                newName: "NotesModelId");

            migrationBuilder.RenameIndex(
                name: "IX_collaborators_notesModelId",
                table: "collaborators",
                newName: "IX_collaborators_NotesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_collaborators_Notes_NotesModelId",
                table: "collaborators",
                column: "NotesModelId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
