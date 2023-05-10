using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetPartner.Api.Migrations
{
    /// <inheritdoc />
    public partial class fixIdeaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ExpectedCost",
                table: "Ideas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ExpectedProfitRatio",
                table: "Ideas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedCost",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "ExpectedProfitRatio",
                table: "Ideas");
        }
    }
}
