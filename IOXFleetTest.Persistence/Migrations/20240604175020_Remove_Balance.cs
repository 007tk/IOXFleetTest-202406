using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOXFleetTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Balance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
