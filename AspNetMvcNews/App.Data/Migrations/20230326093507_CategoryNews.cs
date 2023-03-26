using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategorNews",
                table: "CategorNews");

            migrationBuilder.RenameTable(
                name: "CategorNews",
                newName: "CategoryNews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryNews",
                table: "CategoryNews",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 26, 12, 35, 7, 277, DateTimeKind.Local).AddTicks(2933), new DateTime(2023, 3, 26, 12, 35, 7, 277, DateTimeKind.Local).AddTicks(2948), new DateTime(2023, 3, 26, 12, 35, 7, 277, DateTimeKind.Local).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 26, 12, 35, 7, 277, DateTimeKind.Local).AddTicks(3347), new DateTime(2023, 3, 26, 12, 35, 7, 277, DateTimeKind.Local).AddTicks(3350), new DateTime(2023, 3, 26, 12, 35, 7, 277, DateTimeKind.Local).AddTicks(3349) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryNews",
                table: "CategoryNews");

            migrationBuilder.RenameTable(
                name: "CategoryNews",
                newName: "CategorNews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategorNews",
                table: "CategorNews",
                column: "Id");

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
    }
}
