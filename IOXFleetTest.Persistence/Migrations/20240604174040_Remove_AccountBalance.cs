using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOXFleetTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Remove_AccountBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountBalance",
                table: "Accounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
