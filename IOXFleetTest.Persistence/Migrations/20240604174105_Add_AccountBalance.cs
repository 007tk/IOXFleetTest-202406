using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOXFleetTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_AccountBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AccountBalance",
                table: "Accounts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "Accounts");
        }
    }
}
