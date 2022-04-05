using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddedIsFinishedToLeaderBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Runes");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "LeaderBoards",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "LeaderBoards");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Runes",
                type: "text",
                nullable: true);
        }
    }
}
