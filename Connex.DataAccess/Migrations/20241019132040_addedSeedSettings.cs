using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Connex.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedSeedSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "Logo", "logo.png" },
                    { 2, "Telefon1", "+994 51 434 15 23" },
                    { 3, "Telefon2", "+994 51 434 15 23" },
                    { 4, "TelefonQaynarXett", "+994 51 434 15 23" },
                    { 5, "FacebookLink", "fb.com" },
                    { 6, "InstagramLink", "instagram.com" },
                    { 7, "LinkedinLink", "linkedin.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
