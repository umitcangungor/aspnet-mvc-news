using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "News",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 25, 15, 43, 31, 958, DateTimeKind.Local).AddTicks(194), new DateTime(2023, 3, 25, 15, 43, 31, 958, DateTimeKind.Local).AddTicks(235), new DateTime(2023, 3, 25, 15, 43, 31, 958, DateTimeKind.Local).AddTicks(234) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 25, 15, 43, 31, 958, DateTimeKind.Local).AddTicks(757), new DateTime(2023, 3, 25, 15, 43, 31, 958, DateTimeKind.Local).AddTicks(759), new DateTime(2023, 3, 25, 15, 43, 31, 958, DateTimeKind.Local).AddTicks(758) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "News",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 25, 15, 36, 6, 357, DateTimeKind.Local).AddTicks(4250), new DateTime(2023, 3, 25, 15, 36, 6, 357, DateTimeKind.Local).AddTicks(4270), new DateTime(2023, 3, 25, 15, 36, 6, 357, DateTimeKind.Local).AddTicks(4269) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 25, 15, 36, 6, 357, DateTimeKind.Local).AddTicks(4682), new DateTime(2023, 3, 25, 15, 36, 6, 357, DateTimeKind.Local).AddTicks(4685), new DateTime(2023, 3, 25, 15, 36, 6, 357, DateTimeKind.Local).AddTicks(4684) });
        }
    }
}
