using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommentsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsComments");

            migrationBuilder.DropTable(
                name: "Settings");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 9, 17, 10, 20, 60, DateTimeKind.Local).AddTicks(7887), new DateTime(2023, 4, 9, 17, 10, 20, 60, DateTimeKind.Local).AddTicks(7906), new DateTime(2023, 4, 9, 17, 10, 20, 60, DateTimeKind.Local).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 9, 17, 10, 20, 60, DateTimeKind.Local).AddTicks(8324), new DateTime(2023, 4, 9, 17, 10, 20, 60, DateTimeKind.Local).AddTicks(8326), new DateTime(2023, 4, 9, 17, 10, 20, 60, DateTimeKind.Local).AddTicks(8326) });
        }
    }
}
