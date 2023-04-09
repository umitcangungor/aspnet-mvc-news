using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "NewsComments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "NewsComments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "NewsComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NewsComments");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "NewsComments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "NewsComments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "NewsComments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "NewsComments");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "NewsComments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "NewsComments");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "NewsComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "NewsComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "NewsComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "NewsComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
