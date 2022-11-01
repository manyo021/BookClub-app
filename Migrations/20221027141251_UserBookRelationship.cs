using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClub_app.Migrations
{
    public partial class UserBookRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AllBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllBooks_UserId",
                table: "AllBooks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllBooks_Users_UserId",
                table: "AllBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllBooks_Users_UserId",
                table: "AllBooks");

            migrationBuilder.DropIndex(
                name: "IX_AllBooks_UserId",
                table: "AllBooks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AllBooks");
        }
    }
}
