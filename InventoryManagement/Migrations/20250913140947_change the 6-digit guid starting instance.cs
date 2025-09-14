using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class changethe6digitguidstartinginstance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RestartSequence(
                name: "Id",
                schema: "shared",
                startValue: 100004L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100000,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 14, 9, 47, 406, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100001,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 14, 9, 47, 406, DateTimeKind.Utc).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100002,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 3, 14, 9, 47, 406, DateTimeKind.Utc).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100003,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 14, 9, 47, 406, DateTimeKind.Utc).AddTicks(1732));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RestartSequence(
                name: "Id",
                schema: "shared",
                startValue: 100000L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100000,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 14, 0, 0, 237, DateTimeKind.Utc).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100001,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 14, 0, 0, 237, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100002,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 3, 14, 0, 0, 237, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100003,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 14, 0, 0, 237, DateTimeKind.Utc).AddTicks(3930));
        }
    }
}
