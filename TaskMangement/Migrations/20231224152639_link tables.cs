using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMangement.Migrations
{
    /// <inheritdoc />
    public partial class linktables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doLists_AspNetUsers_SystemUserId",
                table: "doLists");

            migrationBuilder.RenameColumn(
                name: "SystemUserId",
                table: "doLists",
                newName: "systemUserId");

            migrationBuilder.RenameIndex(
                name: "IX_doLists_SystemUserId",
                table: "doLists",
                newName: "IX_doLists_systemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_doLists_AspNetUsers_systemUserId",
                table: "doLists",
                column: "systemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doLists_AspNetUsers_systemUserId",
                table: "doLists");

            migrationBuilder.RenameColumn(
                name: "systemUserId",
                table: "doLists",
                newName: "SystemUserId");

            migrationBuilder.RenameIndex(
                name: "IX_doLists_systemUserId",
                table: "doLists",
                newName: "IX_doLists_SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_doLists_AspNetUsers_SystemUserId",
                table: "doLists",
                column: "SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
