using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewsTitleStringLength2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 9, 18, 48, 58, 423, DateTimeKind.Local).AddTicks(9180), new DateTime(2023, 4, 9, 18, 48, 58, 423, DateTimeKind.Local).AddTicks(9196), new DateTime(2023, 4, 9, 18, 48, 58, 423, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 9, 18, 48, 58, 423, DateTimeKind.Local).AddTicks(9595), new DateTime(2023, 4, 9, 18, 48, 58, 423, DateTimeKind.Local).AddTicks(9597), new DateTime(2023, 4, 9, 18, 48, 58, 423, DateTimeKind.Local).AddTicks(9597) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
    }
}
