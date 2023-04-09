using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewsTitleStringLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 9, 18, 47, 2, 237, DateTimeKind.Local).AddTicks(5156), new DateTime(2023, 4, 9, 18, 47, 2, 237, DateTimeKind.Local).AddTicks(5171), new DateTime(2023, 4, 9, 18, 47, 2, 237, DateTimeKind.Local).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 9, 18, 47, 2, 237, DateTimeKind.Local).AddTicks(5715), new DateTime(2023, 4, 9, 18, 47, 2, 237, DateTimeKind.Local).AddTicks(5719), new DateTime(2023, 4, 9, 18, 47, 2, 237, DateTimeKind.Local).AddTicks(5718) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 9, 17, 32, 59, 774, DateTimeKind.Local).AddTicks(317), new DateTime(2023, 4, 9, 17, 32, 59, 774, DateTimeKind.Local).AddTicks(330), new DateTime(2023, 4, 9, 17, 32, 59, 774, DateTimeKind.Local).AddTicks(329) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 9, 17, 32, 59, 774, DateTimeKind.Local).AddTicks(601), new DateTime(2023, 4, 9, 17, 32, 59, 774, DateTimeKind.Local).AddTicks(603), new DateTime(2023, 4, 9, 17, 32, 59, 774, DateTimeKind.Local).AddTicks(602) });
        }
    }
}
