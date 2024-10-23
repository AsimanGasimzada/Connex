using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connex.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditLanguageSeedDataAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "https://res.cloudinary.com/dlilcwizx/image/upload/v1729631254/connex.az/qqaf2nprjoze4ovdya9o.png");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "https://res.cloudinary.com/dlilcwizx/image/upload/v1729631254/connex.az/cxoiku5tmvxcoxw6tj4m.png");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://res.cloudinary.com/dlilcwizx/image/upload/v1729631254/connex.az/gnw43upf9w6t2xkaxvka.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/rc1flc3kendub8xvmo8a.png");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/ull5rtwaatdqi1qhuidn.png");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/n4p898pyw6gnxopu5hrc.png");
        }
    }
}
