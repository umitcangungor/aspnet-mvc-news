using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewsImageDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsImages");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "News",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "News");

            migrationBuilder.CreateTable(
                name: "NewsImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsImages", x => x.Id);
                });

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
    }
}
