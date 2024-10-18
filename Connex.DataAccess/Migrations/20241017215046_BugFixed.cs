using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Connex.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BugFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "ImagePath", "IsDefault" },
                values: new object[] { 1, "AZE", "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/rc1flc3kendub8xvmo8a.png", true });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "ImagePath" },
                values: new object[,]
                {
                    { 2, "ENG", "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/ull5rtwaatdqi1qhuidn.png" },
                    { 3, "RUS", "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/n4p898pyw6gnxopu5hrc.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "ImagePath" },
                values: new object[,]
                {
                    { -3, "RUS", "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/n4p898pyw6gnxopu5hrc.png" },
                    { -2, "ENG", "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/ull5rtwaatdqi1qhuidn.png" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "ImagePath", "IsDefault" },
                values: new object[] { -1, "AZE", "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/rc1flc3kendub8xvmo8a.png", true });
        }
    }
}
