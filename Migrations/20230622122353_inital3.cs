using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLHBankApp.Migrations
{
    /// <inheritdoc />
    public partial class inital3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Des",
                table: "Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Des",
                table: "Roles",
                type: "longtext",
                nullable: false);
        }
    }
}
