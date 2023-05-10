using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetPartner.Api.Migrations
{
    /// <inheritdoc />
    public partial class fixDbKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ByUserId",
                table: "Ideas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdeaTypeId",
                table: "Ideas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ByUserId",
                table: "Ideas",
                column: "ByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_IdeaTypeId",
                table: "Ideas",
                column: "IdeaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_IdeaTypes_IdeaTypeId",
                table: "Ideas",
                column: "IdeaTypeId",
                principalTable: "IdeaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Users_ByUserId",
                table: "Ideas",
                column: "ByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_IdeaTypes_IdeaTypeId",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Users_ByUserId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_ByUserId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_IdeaTypeId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "ByUserId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "IdeaTypeId",
                table: "Ideas");
        }
    }
}
