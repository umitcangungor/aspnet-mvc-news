using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryNewsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryNews");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 1, 14, 11, 25, 737, DateTimeKind.Local).AddTicks(1619), new DateTime(2023, 4, 1, 14, 11, 25, 737, DateTimeKind.Local).AddTicks(1634), new DateTime(2023, 4, 1, 14, 11, 25, 737, DateTimeKind.Local).AddTicks(1633) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 1, 14, 11, 25, 737, DateTimeKind.Local).AddTicks(2037), new DateTime(2023, 4, 1, 14, 11, 25, 737, DateTimeKind.Local).AddTicks(2039), new DateTime(2023, 4, 1, 14, 11, 25, 737, DateTimeKind.Local).AddTicks(2039) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNews", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 1, 13, 59, 5, 562, DateTimeKind.Local).AddTicks(6752), new DateTime(2023, 4, 1, 13, 59, 5, 562, DateTimeKind.Local).AddTicks(6763), new DateTime(2023, 4, 1, 13, 59, 5, 562, DateTimeKind.Local).AddTicks(6763) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 1, 13, 59, 5, 562, DateTimeKind.Local).AddTicks(6988), new DateTime(2023, 4, 1, 13, 59, 5, 562, DateTimeKind.Local).AddTicks(6990), new DateTime(2023, 4, 1, 13, 59, 5, 562, DateTimeKind.Local).AddTicks(6989) });
        }
    }
}
