using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 6, 22, 53, 30, 204, DateTimeKind.Local).AddTicks(2520), new DateTime(2023, 4, 6, 22, 53, 30, 204, DateTimeKind.Local).AddTicks(2531), new DateTime(2023, 4, 6, 22, 53, 30, 204, DateTimeKind.Local).AddTicks(2531) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 6, 22, 53, 30, 204, DateTimeKind.Local).AddTicks(2739), new DateTime(2023, 4, 6, 22, 53, 30, 204, DateTimeKind.Local).AddTicks(2742), new DateTime(2023, 4, 6, 22, 53, 30, 204, DateTimeKind.Local).AddTicks(2742) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 5, 23, 1, 43, 584, DateTimeKind.Local).AddTicks(1445), new DateTime(2023, 4, 5, 23, 1, 43, 584, DateTimeKind.Local).AddTicks(1455), new DateTime(2023, 4, 5, 23, 1, 43, 584, DateTimeKind.Local).AddTicks(1455) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 5, 23, 1, 43, 584, DateTimeKind.Local).AddTicks(1648), new DateTime(2023, 4, 5, 23, 1, 43, 584, DateTimeKind.Local).AddTicks(1650), new DateTime(2023, 4, 5, 23, 1, 43, 584, DateTimeKind.Local).AddTicks(1649) });
        }
    }
}
