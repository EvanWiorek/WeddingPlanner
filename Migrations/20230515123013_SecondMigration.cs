using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Weddings_WeddingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WeddingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WeddingId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeddingId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId1",
                table: "Users",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WeddingId",
                table: "Users",
                column: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId1",
                table: "Users",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Weddings_WeddingId",
                table: "Users",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId");
        }
    }
}
