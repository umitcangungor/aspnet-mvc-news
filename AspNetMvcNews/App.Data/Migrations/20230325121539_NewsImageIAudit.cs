using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewsImageIAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NewsImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "NewsImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "NewsImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 25, 15, 15, 39, 206, DateTimeKind.Local).AddTicks(561), new DateTime(2023, 3, 25, 15, 15, 39, 206, DateTimeKind.Local).AddTicks(574), new DateTime(2023, 3, 25, 15, 15, 39, 206, DateTimeKind.Local).AddTicks(573) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 25, 15, 15, 39, 206, DateTimeKind.Local).AddTicks(767), new DateTime(2023, 3, 25, 15, 15, 39, 206, DateTimeKind.Local).AddTicks(769), new DateTime(2023, 3, 25, 15, 15, 39, 206, DateTimeKind.Local).AddTicks(768) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NewsImages");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "NewsImages");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NewsImages");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 12, 14, 5, 41, 212, DateTimeKind.Local).AddTicks(9680), new DateTime(2023, 3, 12, 14, 5, 41, 212, DateTimeKind.Local).AddTicks(9692), new DateTime(2023, 3, 12, 14, 5, 41, 212, DateTimeKind.Local).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 12, 14, 5, 41, 212, DateTimeKind.Local).AddTicks(9817), new DateTime(2023, 3, 12, 14, 5, 41, 212, DateTimeKind.Local).AddTicks(9818), new DateTime(2023, 3, 12, 14, 5, 41, 212, DateTimeKind.Local).AddTicks(9817) });
        }
    }
}
