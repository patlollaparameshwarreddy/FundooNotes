using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooNotes.Migrations
{
    public partial class collaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SharedEmail",
                table: "collaborators",
                newName: "SenderEmail");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmail",
                table: "collaborators",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverEmail",
                table: "collaborators");

            migrationBuilder.RenameColumn(
                name: "SenderEmail",
                table: "collaborators",
                newName: "SharedEmail");
        }
    }
}
