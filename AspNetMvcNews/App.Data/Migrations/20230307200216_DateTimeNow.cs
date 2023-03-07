using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 7, 23, 2, 16, 515, DateTimeKind.Local).AddTicks(819), new DateTime(2023, 3, 7, 23, 2, 16, 515, DateTimeKind.Local).AddTicks(830), new DateTime(2023, 3, 7, 23, 2, 16, 515, DateTimeKind.Local).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 7, 23, 2, 16, 515, DateTimeKind.Local).AddTicks(963), new DateTime(2023, 3, 7, 23, 2, 16, 515, DateTimeKind.Local).AddTicks(964), new DateTime(2023, 3, 7, 23, 2, 16, 515, DateTimeKind.Local).AddTicks(963) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });
        }
    }
}
