using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMangement.Migrations
{
    /// <inheritdoc />
    public partial class ourcustomizeuserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "doLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_doLists_SystemUserId",
                table: "doLists",
                column: "SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_doLists_AspNetUsers_SystemUserId",
                table: "doLists",
                column: "SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doLists_AspNetUsers_SystemUserId",
                table: "doLists");

            migrationBuilder.DropIndex(
                name: "IX_doLists_SystemUserId",
                table: "doLists");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "doLists");
        }
    }
}
