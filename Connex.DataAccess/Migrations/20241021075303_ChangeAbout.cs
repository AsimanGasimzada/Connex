using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connex.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "Abouts");
        }
    }
}
